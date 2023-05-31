public class AssetTracker
{
    private List<Asset> _assets = new List<Asset>();

    public void AddMoney(double amount)
    {
        DisplayAssets();

        Console.Write("Which account do you want to add money to? ");
        string title = Console.ReadLine();

        foreach(Asset asset in _assets)
        {
            if(asset.GetTitle() == title)
            {
                asset.AddMoney(amount);
            }
        }
    }

    public void WithdrawMoney(double amount)
    {
        DisplayAssets();

        Console.Write("Which account do you want to withdraw from? ");
        string title = Console.ReadLine();

        foreach(Asset asset in _assets)
        {
            if(asset.GetTitle() == title)
            {
                asset.WithdrawMoney(amount);
            }
        }
    }

    public void AddAsset()
    {
        Console.Write("Name of Account? ");
        string title = Console.ReadLine();

        Console.Write("Current Balance: $");
        string userinput = Console.ReadLine();
        double amount = int.Parse(userinput);

        Asset asset = new Asset(title, amount);
        _assets.Add(asset);
    }

    public void DeleteAsset()
    {
        Console.Write("Name of Account? ");
        string title = Console.ReadLine();
        
        for (int i = 0; i < _assets.Count(); i ++)
        {
            if (_assets[i].GetTitle() == title)
            {
                _assets.RemoveAt(i);
            }
        }
    }

    public void DisplayAssets()
    {
        foreach (Asset asset in _assets)
        {
            asset.DisplayAsset();
        }
    }

    public void TransferMoney()
    {
        Console.Write("From: ");
        string titleFrom = Console.ReadLine();

        Console.Write("To: ");
        string titleTo = Console.ReadLine();

        Console.Write("Amount: $");
        string userinput = Console.ReadLine();
        double amount = double.Parse(userinput);

        foreach(Asset asset in _assets)
        {
            if (titleFrom == asset.GetTitle())
            {
                asset.WithdrawMoney(amount);
            }

            if (titleTo == asset.GetTitle())
            {
                asset.AddMoney(amount);
            }
        }
    }
    public void LoadAssets()
   {
        string[] lines = System.IO.File.ReadAllLines("assets.txt");
        foreach(string line in lines)
        {
            string[] parts = line.Split("|");
            string title = parts[0];
            string amountString = parts[1];

            double amount = double.Parse(amountString);

            Asset asset = new Asset(title, amount);
            _assets.Add(asset);
        }
    }
   

   public void SaveAssets(string filename = "assets.txt")
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            for (int i = 0; i < _assets.Count(); i++)
            {
                outputFile.WriteLine($"{_assets[i].GetTitle()}|{_assets[i].GetAmount()}");
            }
        }
    }
}