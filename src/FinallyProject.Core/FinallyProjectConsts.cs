using FinallyProject.Debugging;

namespace FinallyProject
{
    public class FinallyProjectConsts
    {
        public const string LocalizationSourceName = "FinallyProject";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "9206a0621a4f4dc588fb6ee3f1fa9b61";
    }
}
