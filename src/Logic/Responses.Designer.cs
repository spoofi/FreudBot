﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Spoofi.FreudBot.Logic {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Responses {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Responses() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Spoofi.FreudBot.Logic.Responses", typeof(Responses).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Good, from this time you can use {0} command.
        /// </summary>
        internal static string AddCommandSuccesfullyAddedCommand {
            get {
                return ResourceManager.GetString("AddCommandSuccesfullyAddedCommand", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Usage: 
        ///
        /// /add /commandName [post|get] url ParamName_1|ParamValue_1 ParamName_2|ParamValue_2
        ///
        ///Example: /add /ping get http://test.site/api/site/get page|1
        ///
        ///Note: at the moment I can&apos;t return response of request..
        /// </summary>
        internal static string AddCommandUsageText {
            get {
                return ResourceManager.GetString("AddCommandUsageText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Admin commands:
        ///{0}.
        /// </summary>
        internal static string AdminText {
            get {
                return ResourceManager.GetString("AdminText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Excellent, alias saved!.
        /// </summary>
        internal static string AliasCommand_AliasSaved {
            get {
                return ResourceManager.GetString("AliasCommand_AliasSaved", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Usage:
        ////alias add /alias1 /command param1 param2
        ////alias list - show yours aliases
        ////alias del /alias1 - removes alias1.
        /// </summary>
        internal static string AliasCommand_Usage {
            get {
                return ResourceManager.GetString("AliasCommand_Usage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Command &apos;{0}&apos; not found..
        /// </summary>
        internal static string AliasCommand_ValidateAdd_CommandNotFound {
            get {
                return ResourceManager.GetString("AliasCommand_ValidateAdd_CommandNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Congratulations! You was added to my allowed users list..
        /// </summary>
        internal static string AllowUserCommandCongratulation {
            get {
                return ResourceManager.GetString("AllowUserCommandCongratulation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} now is allowed user.
        /// </summary>
        internal static string AllowUserCommandSuccessAllowUser {
            get {
                return ResourceManager.GetString("AllowUserCommandSuccessAllowUser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Usage:
        ////allowuser [id|@username].
        /// </summary>
        internal static string AllowUserCommandUsage {
            get {
                return ResourceManager.GetString("AllowUserCommandUsage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Oops, you are was deleted from my allowed list :(.
        /// </summary>
        internal static string DisallowUserCommandMessageToUser {
            get {
                return ResourceManager.GetString("DisallowUserCommandMessageToUser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} now is disallowed user.
        /// </summary>
        internal static string DisallowUserCommandSuccess {
            get {
                return ResourceManager.GetString("DisallowUserCommandSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Usage:
        ////disallowuser [id|@username].
        /// </summary>
        internal static string DisallowUserCommandUsage {
            get {
                return ResourceManager.GetString("DisallowUserCommandUsage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to List of available commands (for you): /list
        ///
        ///Note: for using all of available commands, you must be in a list of allowed users.
        ///
        ///Your&apos;s chat identifier is {0}. Send it to @spoofi, if you want to use all my commands..
        /// </summary>
        internal static string HelpText {
            get {
                return ResourceManager.GetString("HelpText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to List of available commands (for you): /list
        ///
        ///Developer: @spoofi
        ///GitHub: https://github.com/spoofi/FreudBot.
        /// </summary>
        internal static string HelpTextForAllowed {
            get {
                return ResourceManager.GetString("HelpTextForAllowed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Available commands:
        ///{0}.
        /// </summary>
        internal static string ListText {
            get {
                return ResourceManager.GetString("ListText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to At the moment I don&apos;t have settings. I think my developer will add them soon..
        /// </summary>
        internal static string SettingsText {
            get {
                return ResourceManager.GetString("SettingsText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hi!
        ///Brief information about me you can see by using command /help.
        /// </summary>
        internal static string StartText {
            get {
                return ResourceManager.GetString("StartText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sorry, but I don&apos;t know this command :(
        ///Use /list to see list of available commands..
        /// </summary>
        internal static string UnknownCommandText {
            get {
                return ResourceManager.GetString("UnknownCommandText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ok, you command successfully running :).
        /// </summary>
        internal static string UserCommandSuccessRun {
            get {
                return ResourceManager.GetString("UserCommandSuccessRun", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User not found.
        /// </summary>
        internal static string UserNotFound {
            get {
                return ResourceManager.GetString("UserNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Oops, something went wrong and I failed to send packet :(.
        /// </summary>
        internal static string WolCommandFailExecuteText {
            get {
                return ResourceManager.GetString("WolCommandFailExecuteText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You have entered incorrect MAC address. Check it and try again.
        /// </summary>
        internal static string WolCommandIncorrectMac {
            get {
                return ResourceManager.GetString("WolCommandIncorrectMac", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Good news! Magic packet sent!.
        /// </summary>
        internal static string WolCommandSuccessExecuteText {
            get {
                return ResourceManager.GetString("WolCommandSuccessExecuteText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Usage:
        ////wol [ip address|hostname] [mac address] [port]
        ///[port] is not a required parameter. By default I use 7.
        ///Example:
        ////wol my.home.site 01:02:03:04:05:06 7.
        /// </summary>
        internal static string WolCommandUsageText {
            get {
                return ResourceManager.GetString("WolCommandUsageText", resourceCulture);
            }
        }
    }
}
