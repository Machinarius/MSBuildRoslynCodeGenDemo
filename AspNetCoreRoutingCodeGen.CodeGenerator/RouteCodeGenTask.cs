using Microsoft.Build.Framework;

namespace AspNetCoreRoutingCodeGen.CodeGenerator
{
    public class RouteCodeGenTask : Microsoft.Build.Utilities.Task
    {
        [Output]
        public string GeneratedFilePath { get; set; }

        [Required]
        public string TargetFolder { get; set; }

        public override bool Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
