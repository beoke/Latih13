using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Latih13_mdiformLanjutan
{
    public class DbDapper
    {
        private string connstring = "Data Source=DESKTOP-B10RQSP;Initial Catalog=LatihanDatabase;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public IEnumerable<NilaiModel> DataNilai(string filter)
        {
            string sql;
            if(filter == "0")
            {
                sql = @"SELECT m.MahasiswaName,mk.MataKuliahName,n.Nilai FROM Nilai n
                            INNER JOIN Mahasiswa m ON n.MahasiswaId = m.MahasiswaId
                            INNER JOIN Matakuliah mk ON n.MatakuliahId = mk.MataKuliahId";
            }
            else
            {
                sql = @"SELECT m.MahasiswaName,mk.MataKuliahName,n.Nilai FROM Nilai n
                            INNER JOIN Mahasiswa m ON n.MahasiswaId = m.MahasiswaId
                            INNER JOIN Matakuliah mk ON n.MatakuliahId = mk.MataKuliahId
                            WHERE MahasiswaName LIKE @fltr+'%' OR MataKuliahName LIKE @fltr+'%'
                            OR Nilai LIKE @fltr+'%'";
            }

            using var koneksi = new SqlConnection(connstring);
            var ListNilai = koneksi.Query<NilaiModel>(sql, new { fltr = filter });
            return ListNilai;
        }
    }
}
