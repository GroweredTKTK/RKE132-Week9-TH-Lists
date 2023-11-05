string folderPath = @"D:\Program Files\Visual Studio\DATA";
string fileName = "shoppinglist.txt";
string filePath = Path.Combine(folderPath, fileName);
List<string> myShopingList = new List<string>();

if (File.Exists(filePath))
{
    myShopingList = GetItemsFromUser();
    File.WriteAllLines(filePath, myShopingList);
    ShowItemsFromList(myShopingList);
}
else
{
    File.Create(filePath).Close();
    Console.WriteLine($"File {fileName} has been created.");
    myShopingList = GetItemsFromUser();
    File.WriteAllLines(filePath, myShopingList);
    ShowItemsFromList(myShopingList);
}


static List<string> GetItemsFromUser()
{
    List<string> userList = new List<string>();

    while (true)
    {
        Console.WriteLine("Add an item or Exit (exit):");
        string userChoise = Console.ReadLine();

        if (userChoise == "exit")
        {
            break;
        }
        else
        {
            //Console.WriteLine("Enter an item: ");
            //string userItem = Console.ReadLine();
            userList.Add(userChoise);
        }       
    }
    return userList;
}

static void ShowItemsFromList(List<string> someList)
{
    Console.Clear();

    int listLength = someList.Count;
    Console.WriteLine($"You have added {listLength} items to your shoping list");
    int i = 1;

    foreach (string item in someList)
    {
        Console.WriteLine($"{i}. {item}");
        i++;
    }
}