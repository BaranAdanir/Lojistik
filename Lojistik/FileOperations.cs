using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lojistik
{
    class FileOperations
    {
       
        public void WriteDataGrid(DataGridView Grid, string Path)
        {

            for(int CurrentRow = 0; CurrentRow < Grid.Rows.Count -1; CurrentRow ++)
            {
                string folderPath = Path + "\\" + CurrentRow.ToString();
                Directory.CreateDirectory(folderPath);
                using (FileStream fs = File.Create(folderPath + "\\" + "properties.txt"))
                {
                }
                StreamWriter sw = new StreamWriter(folderPath + "\\" + "properties.txt");
                for (int CurrentColumn = 0; CurrentColumn < Grid.Columns.Count; CurrentColumn++)
                {   
                    
                    if (CurrentColumn == 10 || CurrentColumn == 11)
                    {
                        sw.WriteLine("Seç");
                    }

                    else if (CurrentColumn == 12)
                    {
                        sw.WriteLine("Sil");
                    }
                    else if(CurrentColumn == 5 || CurrentColumn == 7 || CurrentColumn == 9)
                    {
                        sw.WriteLine("");
                    }
                    else if(Grid[CurrentColumn, CurrentRow].Value == null)
                    {
                        sw.WriteLine("");

                    }
                    

                    else
                    {
                        sw.WriteLine(Grid[CurrentColumn, CurrentRow].Value.ToString());
                    }
                }
                sw.Close();
            }

        }

        public void ReadDataGrid(DataGridView Grid, string Path)
        {
            
            string[] AllFiles = Directory.GetDirectories(Path, "*", SearchOption.TopDirectoryOnly);
            
            int RowCounter = 0;
            
            
            foreach(string CurrentFile in AllFiles)
            {
                
                Grid.Rows.Add();
                using(StreamReader sr = new StreamReader(CurrentFile + "\\" + "properties.txt"))
                {
                    string line;
                    int ColumnCounter = 0;

                    while ((line = sr.ReadLine()) != null)
                    {
                        Grid[ColumnCounter, RowCounter].Value = line;
                        
                        ColumnCounter++;
                    }
                }
                RowCounter++;
            }
        }

        public void ClearFolder(string Path)
        {
            Directory.Delete(Path, true);
            Directory.CreateDirectory(Path);
        }

       
    }
}
