using System.Collections.Generic;

namespace Greg.Conga.WinUI.Model
{
	public class FieldDescriptor : IHaveFields, IHaveId
	{
		public FieldDescriptor(string id, string typeName, object value = null)
		{
			this.Id = id;
			this.TypeName = typeName;
			this.Value = value;
		}

		public string Id { get; private set; }
		public string TypeName { get; private set; }
		public object Value { get; protected set; }
		public List<FieldDescriptor> Fields { get; private set; } = new List<FieldDescriptor>();


		public virtual string AdditionalData { get; }

		public IHaveId Parent { get; set; }


		public string GetPath()
		{
			if (this.Parent == null) return this.Id;

			return this.Parent.GetPath() + "\\" + this.Id;
		}
	}
}
