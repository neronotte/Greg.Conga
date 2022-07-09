using Greg.Conga.Sdk.Messages;
using Greg.Conga.Sdk.Messages.Salesforce;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Greg.Conga.WinUI.Model
{
	public class EntityDescriptor : IHaveFields
	{
		public string Id { get; set; }
		public string TypeName { get; set; }
		public List<FieldDescriptor> Fields { get; private set; } = new List<FieldDescriptor>();


		internal static EntityDescriptor FromDescribeResponse(DescribeResponse metadata, DynamicEntity entity)
		{
			var comparer = new FieldNameComparer();


			var d = new EntityDescriptor();
			d.Id = null;
			d.TypeName = metadata.Name;

			foreach (var field in metadata.Fields.OrderBy( x => x.Name, comparer))
			{
				var value = entity.ContainsKey(field.Name) ? entity[field.Name] : null;

				if (string.Equals("reference", field.Type, StringComparison.OrdinalIgnoreCase))
				{

					var descriptor = new FieldDescriptorReference(field.Name, field.Type, field.ReferenceTo, value);
					d.Fields.Add(descriptor);
				}
				else
				{
					var descriptor = new FieldDescriptor(field.Name, field.Type, value);
					d.Fields.Add(descriptor);
				}
			}

			return d;
		}
	}
}
