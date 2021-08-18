using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace IT481_Fitzpatrick_Unit_3.data
{
    public static class ExtensionMethods
    {
        public static string GetStringOrDbNull(this SqlDataReader reader, int idx)
        {
            if (!reader.IsDBNull(idx))
            {
                return reader.GetString(idx);
            }
            return null;
        }
        public static int? GetInt32OrDbNull(this SqlDataReader reader, int idx)
        {
            if (!reader.IsDBNull(idx))
            {
                return reader.GetInt32(idx);
            }
            return null;
        }
        public static DateTime? GetDateTimeOrDbNull(this SqlDataReader reader, int idx)
        {
            if (!reader.IsDBNull(idx))
            {
                return reader.GetDateTime(idx);
            }
            return null;
        }

    }
}
