namespace Greg.Conga.WinUI.Model
{
	public class FieldDescriptorFake : FieldDescriptor
	{
		public static FieldDescriptorFake Instance { get; } = new FieldDescriptorFake();

		private FieldDescriptorFake() : base("...", "...")
		{
		}
	}
}
