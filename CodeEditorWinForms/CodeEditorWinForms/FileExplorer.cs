using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeEditorWinForms
{
	class FileExplorer
	{
		private TreeView treeView;
		private string currentPath = "";

		public FileExplorer(TreeView treeView)
		{
			this.treeView = treeView;
		}

		public string GetCurrentPath()
		{
			return currentPath;
		}

		public void PopulateTreeView(string path)
		{
			currentPath = path;
			treeView.Nodes.Clear();

			DirectoryInfo directoryInfo = new DirectoryInfo(path);
			if (directoryInfo.Exists)
			{
				BuildTree(directoryInfo, treeView.Nodes);
			}
		}

		private void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
		{
			TreeNode curNode = addInMe.Add(directoryInfo.Name);

			foreach (FileInfo file in directoryInfo.GetFiles())
			{
				curNode.Nodes.Add(file.FullName, file.Name);
			}
			foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
			{
				BuildTree(subdir, curNode.Nodes);
			}
		}
	}
}
