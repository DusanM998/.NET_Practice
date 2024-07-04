using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;

//OutputFileSystemInfo();
//WorkWithDrives();
//WorkWithDirectories();
WorkWithFiles();

//Rukovanje medjuplatformskim okruzenjima i fajl sistemima
static void OutputFileSystemInfo()
{
    WriteLine("{0,-33} {1}", arg0: "Path.Separator", arg1: PathSeparator);
    WriteLine("{0,-33} {1}", arg0: "Path.DirectorySeparatorChar", 
        arg1: DirectorySeparatorChar);
    WriteLine("{0,-33} {1}", arg0: "Directory.GetCurrentDirectory()",
        arg1: GetCurrentDirectory());
    WriteLine("{0,-33} {1}", arg0: "Environment.CurrentDirectory",
        arg1: CurrentDirectory);
    WriteLine("{0,-33} {1}", arg0: "Environment.SystemDirectory",
        arg1: SystemDirectory);
    WriteLine("{0,-33} {1}", arg0: "Path.GetTempPath()",
        arg1: GetTempPath());

    WriteLine("GetFolderPath(SpecialFolder)");
    WriteLine("{0,-33} {1}", arg0: " .System", 
        arg1: GetFolderPath(SpecialFolder.System));
    WriteLine("{0,-33} {1}", arg0: " .ApplicationData", 
        arg1: GetFolderPath(SpecialFolder.ApplicationData));
    WriteLine("{0,-33} {1}", arg0: " .MyDocuments", 
        arg1: GetFolderPath(SpecialFolder.MyDocuments));
    WriteLine("{0,-33} {1}", arg0: " .Personal", 
        arg1: GetFolderPath(SpecialFolder.Personal));
}

//Upravljanje drajvovima
static void WorkWithDrives()
{
    WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18} | {4,18}",
        "NAME", "TYPE", "FORMAT", "SIZE (BYTES)", "FREE SPACE");

    foreach(DriveInfo drive in DriveInfo.GetDrives())
    {
        if(drive.IsReady)
        {
            WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18:N0} | {4,18:N0}",
                drive.Name, drive.DriveType, drive.DriveFormat,
                drive.TotalFreeSpace, drive.TotalFreeSpace);
        }
        else
        {
            WriteLine("{0,-30} | {1,-10}", drive.Name, drive.DriveType);
        }
    }
}

//Upravljanje direktorijumima
static void WorkWithDirectories()
{
    //Define a directory path for a new folder
    //starting in the user's folder
    string newFolder = Combine(
        GetFolderPath(SpecialFolder.Desktop),
        "Code", "Chapter09-vscode", "NewFolder");

    WriteLine($"Working with: {newFolder}");

    //Check if it exists
    WriteLine($"Does it exist? {Exists(newFolder)}");

    //Create directory
    WriteLine("Creating it...");
    CreateDirectory(newFolder);
    WriteLine($"Does it exist? {Exists(newFolder)}");
    Write("Confirm the directory exists, and then press ENTER: ");
    ReadLine();

    //Delete directory
    WriteLine("Deleting it...");
    Delete(newFolder, recursive: true);
    WriteLine($"Does it exist? {Exists(newFolder)}");
}

//Upravljanje fajlovima
static void WorkWithFiles()
{
    //Definisanje putanje direktorijuma za izlazni fajl
    //pocevsi od korisnickog foldera
    string dir = Combine(
        GetFolderPath(SpecialFolder.Desktop),
        "Code", "Chapter09-vscode", "OutputFiles");

    CreateDirectory(dir);

    //Definisanje putanja fajla
    string textFile = Combine(dir, "Dummy.txt");
    string backupFile = Combine(dir, "Dummy.bak");
    WriteLine($"Working with: {textFile}");

    //Provera da li fajl postoji
    WriteLine($"Does it exist? {File.Exists(textFile)}");

    //Create a new text file and write a line to it
    StreamWriter textWriter = File.CreateText(textFile);
    textWriter.WriteLine("Hello, C#!");
    textWriter.Close(); //Zatvaranje fajla i otpustanje resursa
    WriteLine($"Does it exist? {File.Exists(textFile)}");

    //Kopiranje fajla u rezervnu kopiju ili overwrite ako postoji
    File.Copy(sourceFileName: textFile,
        destFileName: backupFile, overwrite: true);
    WriteLine(
        $"Does {backupFile} exist? {File.Exists(backupFile)}");
    Write("Confirm the file exist, and then press ENTER: ");
    ReadLine();

    //Brisanje fajla
    File.Delete(textFile);
    WriteLine($"Does it exist? {File.Exists(textFile)}");

    //Citanje iz backup txt fajla
    WriteLine($"Reading contents of {backupFile}: ");
    StreamReader textReader = File.OpenText(backupFile);
    WriteLine(textReader.ReadToEnd());
    textWriter.Close();

    //Upravljanje putanjama
    WriteLine($"Folder Name: {GetDirectoryName(textFile)}");
    WriteLine($"File Name: {GetFileName(textFile)}");

    WriteLine("File name without extension: {0}",
        GetFileNameWithoutExtension(textFile));
    WriteLine($"File Extension: {GetExtension(textFile)}");
    WriteLine($"Random File Name: {GetRandomFileName()}");
    WriteLine($"Temporary File Name: {GetTempFileName()}");

    //Preuzimanje informacija o fajlu
    FileInfo info = new(backupFile);
    WriteLine($"{backupFile}:");
    WriteLine($"Contains {info.Length} bytes.");
    WriteLine($"Last accessed {info.LastAccessTime}");
    WriteLine($"Has readonly set to: {info.IsReadOnly}");
}
