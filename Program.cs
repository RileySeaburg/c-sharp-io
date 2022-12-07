using System.IO;
using System.Text;

internal class Program
{
  private static void Main(string[] args)
  {
    decimal discountPercent = .2m;     // 20% discount
    decimal price = 100m;              // $100 price
    price = price * 1 - discountPercent; // price = $99.8

    Console.WriteLine("Price = " + price);


    // get current directory and assign it to a variable of
    // type DirectoryInfo and name currentDir.
    DirectoryInfo currentDir = new DirectoryInfo(".");

    // Get users directory
    DirectoryInfo userDir = new DirectoryInfo(@"C:\Users\riley");

    Console.WriteLine(userDir.FullName);
    Console.WriteLine(userDir.Name);
    Console.WriteLine(userDir.Parent);
    Console.WriteLine(userDir.Attributes);
    Console.WriteLine(userDir.CreationTime);


    string dataDir = @"C:\Users\riley\C#data";

    if (!Directory.Exists(dataDir))
    {
      Directory.CreateDirectory(dataDir);
      Console.WriteLine("Data directory created at " + dataDir);
    }
    else
    {
      Console.WriteLine("Folder already present.");
    }

    string[] customers = {
  "Stece",
  "Johdee",
  "Rhonee",
  "Steve",
  "Aaron"
};

    string textFilePath = @"C:\Users\riley\C#data\testfile1.txt";



    File.WriteAllLines(textFilePath, customers);

    foreach (string cust in File.ReadAllLines(textFilePath))
    {
      Console.WriteLine($"Customer : {cust}");
    }

    DirectoryInfo mydataDir = new DirectoryInfo(dataDir);

    Console.WriteLine("This is your directory {0}", mydataDir);

    FileInfo[] textFiles = mydataDir.GetFiles("*.txt", SearchOption.AllDirectories);

    Console.WriteLine("Matches : {0}", textFiles.Length);

    foreach (FileInfo file in textFiles)
    {
      Console.WriteLine(file.Name);
      Console.WriteLine(file.Length);
    }

    // "//" is required because othwise regex kicks in.
    string textFilePath2 = dataDir + "\\testfile2.txt";

    System.Console.WriteLine("Your text file path 2: {0}", textFilePath2);
    FileStream fs = File.Open(textFilePath2, FileMode.Create);

    var randString = new Random().Next(10, 50).ToString();

    byte[] rsByteArray = Encoding.Default.GetBytes(randString);

    fs.Write(rsByteArray, 0, rsByteArray.Length);

    fs.Position = 0;

    byte[] filebyteArray = new byte[rsByteArray.Length];

    for (int i = 0; i < rsByteArray.Length; i++)
    {
      filebyteArray[i] = (byte)fs.ReadByte();
    }

    System.Console.WriteLine(Encoding.Default.GetString(filebyteArray));

    fs.Close();


    string textFilePath3 = dataDir + "\\textfile3.txt";

    StreamWriter sw = File.CreateText(textFilePath3);

    sw.Write("This is a random ");
    sw.WriteLine("A man thought to himself....");
    sw.WriteLine("Why???");

    sw.Close();

    StreamReader sr = File.OpenText(textFilePath3);

    System.Console.WriteLine("Peek : {0}", Convert.ToChar(sr.Peek()));

    System.Console.WriteLine("1st String : {0}", sr.ReadLine());

    System.Console.WriteLine("You file bruh : {0}", sr.ReadToEnd());

    sr.Close();

    string textFilePath4 = dataDir + "\\testfile4.dat";

    FileInfo datfile = new FileInfo(textFilePath4);

    BinaryWriter bw = new BinaryWriter(datfile.OpenWrite());

    string randNum = new Random().Next(1, 100000000).ToString();
    int randNum1 = new Random().Next(1, 100000000);
    var randNum2 = new Random().Next(1, 100000000);

    var randNum3 = randNum2 * .05; 

    bw.Write(randNum);

    bw.Write(randNum1);

    bw.Write(randNum3);

    bw.Close();

    BinaryReader br = new BinaryReader(datfile.OpenRead());
    System.Console.WriteLine(br.ReadString());

    System.Console.WriteLine(br.ReadInt32());

    System.Console.WriteLine(br.ReadDouble());

    br.Close();
  }

}