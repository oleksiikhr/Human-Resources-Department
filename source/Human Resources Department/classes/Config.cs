﻿using System;

namespace Human_Resources_Department.classes
{
    class Config
    {
        public const string PROJECT_NAME = "Human Resources Department";

        public string projectFolder =
            Environment.GetFolderPath(Environment.SpecialFolder.Personal)
            + "\\" + PROJECT_NAME;

        public string currentFolder;

        public string CurrentFolder
        {
            get
            {
                return currentFolder;
            }
            set
            {
                currentFolder = value;
            }
        }
    }
}