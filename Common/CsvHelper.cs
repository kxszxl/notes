public static class CsvHelper
{
	private static Dictionary<int, CTest> _csvCTest = null;
	public static Dictionary<int, CTest> CsvCTest
	{
		get
		{
			if (_csvCTest == null)
			{ _csvCTest = LoadDate<CTest>(System.AppDomain.CurrentDomain.BaseDirectory + "test.csv"); }
			return _csvCTest;
		}
	}
	public static List<List<string>> LoadFile(string path)
	{
		string[] allLine = File.ReadAllLines(path);
		List<List<string>> fileData = new List<List<string>>();
		foreach (string line in allLine)
		{
			List<string> lineData =new List<string>(line.Split(','));
			fileData.Add(lineData);
		}

		return fileData;
	}
	public static Dictionary<int, T> LoadDate<T>(string path)
	{
		Dictionary<int, T> data = new Dictionary<int, T>();
		List<List<string>> fileData = LoadFile(path);
		Dictionary<string, int> key = new Dictionary<string, int>();
		for (int i = 0; i < fileData[0].Count; i++)
		{
			key.Add(fileData[0][i], i);
		}
		for (int row = 1; row < fileData.Count; row++)
		{
			T obj = Activator.CreateInstance<T>();
			PropertyInfo[] properties = typeof(T).GetProperties();
			foreach (PropertyInfo pi in properties)
			{
				pi.SetValue(obj,Convert.ChangeType(fileData[row][key[pi.Name]],pi.PropertyType),null);
			}
			data.Add(Convert.ToInt32(fileData[row][0]), obj);
		}
		return data;
	}
}
public class CTest
{
	public int Id { get; set; }
	public string 字段1 { get; set; }
	public string 字段2 { get; set; }
	public string 字段3 { get; set; }
}