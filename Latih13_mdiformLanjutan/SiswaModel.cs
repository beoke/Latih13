using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Latih13_mdiformLanjutan
{
    public class SiswaModel
    {
        [Key]
        public int SiswaId { get; set; }
        public string SiswaName { get; set; } = string.Empty;
        public string Nis { get; set; } = string.Empty;
        public DateTime TglLahir { get; set; } = new DateTime(1900, 1, 1);
        public string TempatLahir { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Alamat { get; set; } = string.Empty;
        public string Kota { get; set; } = string.Empty;
    }
}
