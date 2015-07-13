public class FileStore: IStore
{
	private readonly workingDirectory;
	
	public FileStore(DirectoryInfo workingDirectory)
	{
		if (workingDirectory == null)
			throw new ArgumentNullException("workingDirectory");
			
		if(!Directory.Exists(workingDirectory)))
			throw new ArgumentException("Invalid working directory, directory does not exist!","workingDirectory");
					
		this.workingDirectory = workingDirectory;
	}
	
	public virtual void WriteAllText(int id, string message)
	{
		var path = this.GetFileInfo(id);
		File.WriteAllText(path, message);
	}
	
	public virtual string ReadAllText(int id)
	{
		var file = this.GetFileInfo(id);
		if(!file.Exists)
			return new Maybe<string>();
		var path = file.FullName;
		return File.ReadAllText(path);
	}
	
	public virtual FileInfo GetFileInfo(int id)
	{
		var path = Path.Combine(this.workingDirectory.FullName, id + ".txt");
		return new FileInfo(path);
	}
}