namespace Greg.Conga.WinUI.Model
{
	public class FieldDescriptorReference : FieldDescriptor
	{
		public FieldDescriptorReference(string id, string typeName, string[] referenceTo, object value) : base(id, typeName, value)
		{
			this.ReferenceTo = referenceTo;

			if (this.Value != null)
				this.Fields.Add(FieldDescriptorFake.Instance);
		}

		public string[] ReferenceTo { get; }

		public override string AdditionalData => string.Join(", ", this.ReferenceTo);
	}
}
