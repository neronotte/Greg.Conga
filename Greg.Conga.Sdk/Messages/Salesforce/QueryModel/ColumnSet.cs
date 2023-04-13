using System.Collections.Generic;

namespace Greg.Conga.Sdk.Messages.Salesforce.QueryModel
{
    public sealed class ColumnSet : List<string>
    {
        public override string ToString()
        {
            if (this.Count == 0)
            {
                return "Id";
            }

            return string.Join(", ", this);
        }
    }
}
