using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.CustomDataStructures.TreesAndGraphs
{
    public class Folder
    {
        private string _name;
        private CustomFile[] _files;
        private Folder[] _childFolders;
        public Folder(string name)
        {
            _name = name;
            _files = new CustomFile[10];
            _childFolders = new Folder[10];
        }
        public int FileCount
        {
            get { return FilesCount(); }
        }
        public int SubFolderCount
        {
            get
            {
                return SubFoldersCount();
            }
        }

        public void AddFile(CustomFile file)
        {
            if (FileCount == _files.Length)
            {
                CustomFile[] filesNew = new CustomFile[_files.Length * 2];
                Array.Copy(_files, filesNew, _files.Length);
                int oldLength = _files.Length;
                _files = filesNew;
                _files[oldLength] = file;


            }
            else
            {
                for (int i = 0; i < _files.Length; i++)
                {
                    if (_files[i] == null)
                    {
                        _files[i] = file;
                        break;
                    }
                }
            }
        }
        public void AddFolder(Folder folder)
        {
            if (SubFolderCount == _childFolders.Length)
            {
                Folder[] childFoldersNew = new Folder[_childFolders.Length * 2];
                Array.Copy(_childFolders, childFoldersNew, _childFolders.Length);
                int oldLength = _childFolders.Length;
                _childFolders = childFoldersNew;
                _childFolders[oldLength] = folder;

            }
            else
            {
                _childFolders[SubFolderCount] = folder;
            }

        }
        public CustomFile GetFile(int index)
        {
            return _files[index];
        }
        public Folder GetSubFolder(int index)
        {
            return _childFolders[index];
        }
        private int SubFoldersCount()
        {
            int count = 0;
            for (int i = 0; i < _childFolders.Length; i++)
            {
                if (_childFolders[i] == null)
                    break;
                count++;
            }
            return count;
        }

        private int FilesCount()
        {
            int count = 0;
            for (int index = 0; index < _files.Length; index++)
            {
                if (_files[index] == null)
                    break;
                count++;
            }
            return count;
        }
                

            
        
    }
}
