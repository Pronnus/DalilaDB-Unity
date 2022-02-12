using UnityEditor;
using static U.DalilaDB.Editor.UE;

namespace U.Reactor.Editor
{
    public class CreateCollectionMenuButton : EditorWindow
    {

        #region File
        private static string DefaultFolderName => "/Scripts/DalilaDocs/Models/";
        private static string DefaultFileName => "NewCC";
        private static string CustomExtension => "collection";
        static string[] File(string fileName) => new string[]
        {
            "using System.Runtime.Serialization;",
            "using U.DalilaDB;",
            "using UnityEngine;",
            "using System.Collections.Generic;",
            "",
            "public static partial class DBmodels",
            "{",
            "    [KnownType(typeof("+fileName+"))]",
            "    [DataContract()]",
            "    public class "+fileName+" : DalilaDBCollection<"+fileName+">",
            "    {",
            "",
            "        #region Config",
            "",
            "        //protected override string rootPath_ => Application.persistentDataPath;  // Change default data save path ",
            "        //protected override int cacheSize_ => 10;  // Number of elements in cache",
            "        //protected override bool _aesEncryption => true;  // Enable encryption",
            "        //protected override DalilaFS.aesValidKeySizes _aesKeySize => DalilaFS.aesValidKeySizes.aes256;  // Aes key size",
            "        //protected override string _aesFixedKey => "+quote+"TheKeyIsNew"+quote+";  // Aes Key",
            "",
            "        #endregion Config",
            "",
            "",
            "        // Write members here",
            "",
            "        //[DataMember()]",
            "        //public string playerName { get; set; }",
            "",
            "        //[DataMember()]",
            "        //public int maxScore { get; set; }",
            "",
            "        //...",
            "",
            "    }",
            "}",
        };
        #endregion File



        private static string FormatLog(string text) => "DalilaDB: " + text;


        [MenuItem("Universal/DalilaDB/Create/Collection")]
        public static void ShowWindow()
        {

            // Create files
            CreateFileWithSaveFilePanelAndCustomExtension(DefaultFolderName, DefaultFileName, File, FormatLog, CustomExtension);

            // Compile
            AssetDatabase.Refresh();

        }

    }
}