using JetBrains.Application.Settings;
using JetBrains.ReSharper.Daemon;
using JetBrains.ReSharper.Daemon.Stages;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;

namespace CitizenMatt.ReSharper.StyleCopComments
{
    [FileStructureExplorer]
    public class CSharpFileStructureExplorer : IFileStructureExplorer
    {
        public IFileStructure Run(IDaemonProcess process, IPsiSourceFile psiSourceFile, IContextBoundSettingsStore settingsStore, IFile file)
        {
            var cSharpFile = file as ICSharpFile;
            if (cSharpFile == null)
                return null;

            return new MyCSharpFileStructure(cSharpFile);
        }
    }

    public class MyCSharpFileStructure : FileStructureBase
    {
        public MyCSharpFileStructure(IFile file) : base(file)
        {
            ProcessFile();
        }

        private void ProcessFile()
        {
            new RecursiveElementProcessor<ICSharpCommentNode>(comment =>
                {
                    // StyleCop has requirements for blank lines after "//"-style comments which are
                    // ignored if the comment begins with four slashes ("////"). ReSharper doesn't
                    // natively support disabling warnings like this, so we'll do it here. Check the
                    // comment text (the bit after the first two slashes). If it starts with another
                    // two slashes, strip them, and pass to the normal handling. Since we're another
                    // class, and we need to keep track of start and end ranges, we can't mix and
                    // match - if you use "//// resharper disable..." you MUST use "//// resharper restore"
                    var commentText = comment.CommentText;
                    if (commentText.StartsWith("//"))
                        ProcessComment(comment.GetTreeStartOffset(), comment.CommentText.Substring(2));
                }).Process(File);

            CloseAllRanges(File);
        }
    }
}