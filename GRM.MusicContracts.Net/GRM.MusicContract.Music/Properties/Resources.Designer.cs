﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GRM.MusicContract.Music.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("GRM.MusicContract.Music.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Artist|Title|Usages|StartDate|EndDate
        ///Tinie Tempah|Frisky (Live from SoHo)|digital download, streaming|1st Feb 2012|
        ///Tinie Tempah|Miami 2 Ibiza|digital download|1st Feb 2012|
        ///Tinie Tempah|Till I&apos;m Gone|digital download|1st Aug 2012|
        ///Monkey Claw|Black Mountain|digital download|1st Feb 2012|
        ///Monkey Claw|Iron Horse|digital download, streaming|1st June 2012|
        ///Monkey Claw|Motor Mouth|digital download, streaming|1st Mar 2011|
        ///Monkey Claw|Christmas Special|streaming|25st Dec 2012|31st Dec 2012.
        /// </summary>
        internal static string MusicContract {
            get {
                return ResourceManager.GetString("MusicContract", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Partner|Usage
        ///ITunes|digital download
        ///YouTube|streaming
        /// </summary>
        internal static string Partner {
            get {
                return ResourceManager.GetString("Partner", resourceCulture);
            }
        }
    }
}