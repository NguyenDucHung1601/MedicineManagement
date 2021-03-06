﻿using MedicineManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicineManagement.Controllers
{
    class ControllerMedicine: ControllerBase
    {
        public ControllerMedicine() : base()
        {
            ;
        }
        public override DataTable Load()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM DBO.MEDICINE";
                adapter.SelectCommand = new SqlCommand(query, connection);
                cb = new SqlCommandBuilder(adapter);
                adapter.Fill(ds, "MEDICINE");
                dt = ds.Tables["MEDICINE"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            connection.Close();
            return dt;
        }

        public DataTable Search(Medicine medicine)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = this.QuerySearch(medicine);
                ds.Clear();
                if (query == "")
                {
                    return this.Load();
                }
                else
                {
                    adapter.SelectCommand = new SqlCommand(query, connection);
                    cb = new SqlCommandBuilder(adapter);
                    adapter.Fill(ds, "MEDICINE");
                    dt = ds.Tables["MEDICINE"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        private string QuerySearch(Medicine medicine)
        {
            string sqlSelect = "";

            string ID_Medicine; try { ID_Medicine = medicine.ID_Medicine.ToString().Trim(); } catch { ID_Medicine = ""; }
            string Name; try { Name = medicine.Name.ToString().Trim(); } catch { Name = ""; }
            string MedicineGroup; try { MedicineGroup = medicine.MedicineGroup.ToString().Trim(); } catch { MedicineGroup = ""; }
            string Search_MinPrice; try { Search_MinPrice = medicine.Search_MinPrice.ToString().Trim(); } catch { Search_MinPrice = ""; }
            string Search_MaxPrice; try { Search_MaxPrice = medicine.Search_MaxPrice.ToString().Trim(); } catch { Search_MaxPrice = ""; }
            string Search_MinTotalInventory; try { Search_MinTotalInventory = medicine.Search_MinTotalInventory.ToString().Trim(); } catch { Search_MinTotalInventory = ""; }
            string Search_MaxTotalInventory; try { Search_MaxTotalInventory = medicine.Search_MaxTotalInventory.ToString().Trim(); } catch { Search_MaxTotalInventory = ""; }
            string Search_StartMostUsedMonth; try { Search_StartMostUsedMonth = medicine.Search_StartMostUsedMonth.ToString().Trim(); } catch { Search_StartMostUsedMonth = ""; }
            string Search_EndMostUsedMonth; try { Search_EndMostUsedMonth = medicine.Search_EndMostUsedMonth.ToString().Trim(); } catch { Search_EndMostUsedMonth = ""; }

            if (ID_Medicine != "") { sqlSelect = sqlSelect + " and ID_Medicine like '%" + ID_Medicine + "%'"; }
            if (Name != "") { sqlSelect = sqlSelect + " and Name like '%" + Name + "%'"; }
            if (MedicineGroup != "") { sqlSelect = sqlSelect + " and MedicineGroup like '%" + MedicineGroup + "%'"; }
            if (Search_MinPrice != "") { sqlSelect = sqlSelect + " and Price >= " + Search_MinPrice; }
            if (Search_MaxPrice != "") { sqlSelect = sqlSelect + " and Price <= " + Search_MaxPrice; }
            if (Search_MinTotalInventory != "") { sqlSelect = sqlSelect + " and TotalInventory >= " + Search_MinTotalInventory; }
            if (Search_MaxTotalInventory != "") { sqlSelect = sqlSelect + " and TotalInventory <= " + Search_MaxTotalInventory; }
            if (Search_StartMostUsedMonth != "") { sqlSelect = sqlSelect + " and MostUsedMonth >= " + Search_StartMostUsedMonth; }
            if (Search_EndMostUsedMonth != "") { sqlSelect = sqlSelect + " and MostUsedMonth <= " + Search_EndMostUsedMonth; }

            string query = "";
            if (sqlSelect != "")
            {
                sqlSelect = sqlSelect.Remove(0, 4); // xoa chu " and" dau tien
                sqlSelect = " WHERE" + sqlSelect;
                query = "SELECT* FROM DBO.MEDICINE" + sqlSelect;
            }
            return query;
        }
    }
}
