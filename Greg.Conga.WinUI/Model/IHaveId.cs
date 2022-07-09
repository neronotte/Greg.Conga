namespace Greg.Conga.WinUI.Model
{
	public interface IHaveId
	{
		string Id { get; }

		string GetPath();
	}
}
