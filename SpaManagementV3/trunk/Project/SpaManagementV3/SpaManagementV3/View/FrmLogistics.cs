using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using Telerik.WinControls.UI;
using SpaCommon;
using SpaDatabase.Model.Entities;

namespace SpaManagementV3.View
{
    public partial class FrmLogistics : Telerik.WinControls.UI.RadForm
    {
        public FrmLogistics()
        {
            InitializeComponent();

            InitializeGridview(dtgSupplier);
            InitializeGridview(dtgWarehouse);
            InitializeGridview(dtgImport);
            InitializeGridview(dtgExport);



        }

        private void Row_Formatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            e.RowElement.Font = new Font(this.Font.Name, (float)9);
        }

        private void dtgService_CreateCell(object sender, GridViewCreateCellEventArgs e)
        {
            if (e.CellType == typeof(GridRowHeaderCellElement) && e.Row is GridDataRowElement)
            {
                e.CellType = typeof(SpreadsheetGridRowHeaderCellElement);
            }
        }

        private void InitializeGridview(RadGridView grid)
        {
            grid.TableElement.RowHeaderColumnWidth = 42;
        }

        private void FrmLogistics_Load(object sender, EventArgs e)
        {
            LoadData();
            InitEvent();
        }

        #region graphics
        private void PrepareForCreatingNewSupplier()
        {
            txtSupplierName.Clear();
            txtSupplierCode.Clear();
            txtContactPerson.Clear();
            txtPhone.Clear();
            txtAccNumber.Clear();
            txtAddress.Clear();
        }

        private void PrepareForCreatingNewWarehouse()
        {
            txtWarehouseName.Clear();
            txtWarehouseCode.Clear();
        }

        private void PrepareForCreatingNewImport()
        {
            spinImportQty.Value = 0;
            txtImportNote.Clear();
        }
        private void PrepareForCreatingNewExport()
        {
            cbbxExportServiceCode.Text = "";
            cbbxExportServiceName.Text = "";
            lbAvailable.Text = "";
            txtSeri.Clear();
            spinExportQty.Value = 0;
            txtExportNote.Clear();
        }

        #endregion

        #region event
        private void pageMain_SelectedPageChanged(object sender, EventArgs e)
        {
            if (pageMain.SelectedPage.Equals(pageImport) || pageMain.SelectedPage.Equals(pageExport))
            {
                List<Warehouse> warehouses = Program.Server.GetWarehouses();
                DataTable tbl = new DataTable();
                tbl.TableName = "Warehouses";
                tbl.Columns.Add("Id", typeof(int));
                tbl.Columns.Add("Name", typeof(string));
                tbl.Columns.Add("Type", typeof(int));
                for (int j = 0; j < warehouses.Count; j++)
                {
                    tbl.Rows.Add(new object[] { warehouses[j].Id, warehouses[j].Name, warehouses[j].WarehouseType });
                }

                BindingSource bs = new BindingSource();
                bs.DataSource = tbl;

                if (pageMain.SelectedPage.Equals(pageImport))
                {
                    cbbxImportWarehouse.DataSource = bs;
                    cbbxImportWarehouse.DisplayMember = "Name";
                }
                else if (pageMain.SelectedPage.Equals(pageExport))
                {
                    cbbxExportWarehouse.DataSource = bs;
                    cbbxExportWarehouse.DisplayMember = "Name";
                    RefreshDataSourceForExporting();
                }

            }
        }
        private void Supplier_Click(object sender, EventArgs e)
        {
            string name = txtSupplierName.Text;
            string code = txtSupplierCode.Text;
            string contactPerson = txtContactPerson.Text;
            string phone = txtPhone.Text;
            string account = txtAccNumber.Text;
            string address = txtAddress.Text;

            if (sender.Equals(btnAddSupplier))
            {
                Supplier sup = null;
                ErrorCode error = Program.Server.AddNewSupplier(name, code, contactPerson, phone, account, address, out sup);
                MessageHandler.MessageManager(this,  error);
                if (error == ErrorCode.OK)
                {
                    dtgSupplier.Rows.Add(new object[] { sup.Id, name, code, contactPerson, phone, account, address });
                    PrepareForCreatingNewSupplier();
                }
            }
            else if (sender.Equals(btnUpdateSupplier))
            {
                if (dtgSupplier.SelectedRows.Count > 0)
                {
                    int id = (int)(decimal)dtgSupplier.SelectedRows[0].Cells[0].Value;
                    ErrorCode error = Program.Server.UpdateSupplier(id, name, code, contactPerson, phone, account, address);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgSupplier.SelectedRows[0].Cells[1].Value = name;
                        dtgSupplier.SelectedRows[0].Cells[2].Value = code;
                        dtgSupplier.SelectedRows[0].Cells[3].Value = contactPerson;
                        dtgSupplier.SelectedRows[0].Cells[4].Value = phone;
                        dtgSupplier.SelectedRows[0].Cells[5].Value = account;
                        dtgSupplier.SelectedRows[0].Cells[6].Value = address;
                        PrepareForCreatingNewSupplier();
                    }
                }
            }
            else if (sender.Equals(btnDeleteSupplier))
            {
                if (dtgSupplier.SelectedRows.Count > 0)
                {
                    int id = (int)(decimal)dtgSupplier.SelectedRows[0].Cells[0].Value;
                    ErrorCode error = Program.Server.DeleteSupplier(id);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgSupplier.SelectedRows[0].Delete();
                        PrepareForCreatingNewSupplier();
                    }
                }
            }
            else if (sender.Equals(dtgSupplier))
            {
                if (dtgSupplier.SelectedRows.Count > 0)
                {
                    txtSupplierName.Text = (string)dtgSupplier.SelectedRows[0].Cells[1].Value;
                    txtSupplierCode.Text = (string)dtgSupplier.SelectedRows[0].Cells[2].Value;
                    txtContactPerson.Text = (string)dtgSupplier.SelectedRows[0].Cells[3].Value;
                    txtPhone.Text = (string)dtgSupplier.SelectedRows[0].Cells[4].Value;
                    txtAccNumber.Text = (string)dtgSupplier.SelectedRows[0].Cells[5].Value;
                    txtAddress.Text = (string)dtgSupplier.SelectedRows[0].Cells[6].Value;
                }
            }
        }
        private void Warehouse_Click(object sender, EventArgs e)
        {
            string warehouseName = txtWarehouseName.Text.Trim();
            string warehouseCode = txtWarehouseCode.Text.Trim();
            ServiceType type = (ServiceType)cbbxGoodsType.SelectedItem.Value;

            if (sender.Equals(btnAddWarehouse))
            {
                Warehouse warehouse = null;
                ErrorCode error = Program.Server.AddNewWarehouse(warehouseName, warehouseCode, type, out warehouse);
                MessageHandler.MessageManager(this, error);
                if (error == ErrorCode.OK)
                {
                    dtgWarehouse.Rows.Add(new object[] { warehouse.Id, warehouse.Name, warehouse.Code, warehouse.WarehouseType.ToString() });
                    PrepareForCreatingNewWarehouse();
                }
            }
            else if (sender.Equals(btnUpdateWarehouse))
            {
                if (dtgWarehouse.SelectedRows.Count > 0)
                {
                    int id = (int)(decimal)dtgWarehouse.SelectedRows[0].Cells[0].Value;
                    ErrorCode error = Program.Server.UpdateWarehouse(id, warehouseName, warehouseCode, type);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgWarehouse.SelectedRows[0].Cells[1].Value = warehouseName;
                        dtgWarehouse.SelectedRows[0].Cells[2].Value = warehouseCode;
                        dtgWarehouse.SelectedRows[0].Cells[3].Value = type.ToString();
                        PrepareForCreatingNewWarehouse();

                    }
                }
            }
            else if (sender.Equals(btnDeleteWarehouse))
            {
                if (dtgWarehouse.SelectedRows.Count > 0)
                {
                    int id = (int)(decimal)dtgWarehouse.SelectedRows[0].Cells[0].Value;
                    ErrorCode error = Program.Server.DeleteWarehouse(id);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgWarehouse.SelectedRows[0].Delete();
                        PrepareForCreatingNewWarehouse();
                    }
                }
            }
            else if (sender.Equals(dtgWarehouse))
            {
                if (dtgWarehouse.SelectedRows.Count > 0)
                {
                    txtWarehouseName.Text = (string)dtgWarehouse.SelectedRows[0].Cells[1].Value;
                    txtWarehouseCode.Text = (string)dtgWarehouse.SelectedRows[0].Cells[2].Value;
                    cbbxGoodsType.SelectedIndex = cbbxGoodsType.Items.IndexOf((string)dtgWarehouse.SelectedRows[0].Cells[3].Value);
                }
            }
        }
        private void Import_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnImport))
            {
                if ((cbbxImportWarehouse.SelectedItem != null) && (cbbxImportServiceCode.SelectedItem != null))
                {
                    string warehouseName = cbbxImportWarehouse.SelectedItem.Text;
                    string serviceCode = cbbxImportServiceCode.SelectedItem.Text;
                    string serviceName = cbbxImportServiceName.SelectedItem.Text;
                    int qty = (int)spinImportQty.Value;
                    string importBy = txtImportBy.Text.Trim();
                    string note = txtImportNote.Text.Trim();

                    if (importBy == "")
                    {
                        MessageHandler.MessageManager(this, ErrorCode.FULFIllDATA_IMPORTBY);
                    }
                    else
                    {
                        Import import = null;
                        ErrorCode error = Program.Server.AddNewImport(warehouseName, serviceCode, qty, importBy, note, out import);
                        MessageHandler.MessageManager(this, error);
                        if (error == ErrorCode.OK)
                        {
                            dtgImport.Rows.Add(new object[] { import.Id, serviceName, serviceCode, qty, importBy, import.ImportAt, note, warehouseName });
                            PrepareForCreatingNewImport();
                        }
                    }
                }

            }
            else if (sender.Equals(cbbxImportWarehouse))
            {
                ServiceType type = (ServiceType)((DataRowView)((BindingSource)cbbxImportWarehouse.DataSource).Current)["Type"];
                switch (type)
                {
                    case ServiceType.Certificate:
                        List<Certificate> certificates = Program.Server.GetCertificates();
                        DataTable tbl = new DataTable();
                        tbl.Columns.Add("Id", typeof(int));
                        tbl.Columns.Add("Name", typeof(string));
                        tbl.Columns.Add("Code", typeof(string));
                        for (int j = 0; j < certificates.Count; j++)
                        {
                            tbl.Rows.Add(new object[] { certificates[j].Id, certificates[j].Name, certificates[j].Code });
                        }

                        BindingSource bs = new BindingSource();
                        bs.DataSource = tbl;
                        cbbxImportServiceName.DataSource = bs;
                        cbbxImportServiceName.DisplayMember = "Name";
                        cbbxImportServiceCode.DataSource = bs;
                        cbbxImportServiceCode.DisplayMember = "Code";

                        break;
                    case ServiceType.OtherService:
                        List<OtherService> otherServices = Program.Server.GetOtherServices();
                        DataTable tbl1 = new DataTable();
                        tbl1.Columns.Add("Id", typeof(int));
                        tbl1.Columns.Add("Name", typeof(string));
                        tbl1.Columns.Add("Code", typeof(string));
                        for (int j = 0; j < otherServices.Count; j++)
                        {
                            tbl1.Rows.Add(new object[] { otherServices[j].Id, otherServices[j].Name, otherServices[j].Code });
                        }

                        BindingSource bs1 = new BindingSource();
                        bs1.DataSource = tbl1;
                        cbbxImportServiceName.DataSource = bs1;
                        cbbxImportServiceName.DisplayMember = "Name";
                        cbbxImportServiceCode.DataSource = bs1;
                        cbbxImportServiceCode.DisplayMember = "Code";
                        break;
                }
            }
        }
        private void Export_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnExport))
            {
                if ((cbbxExportWarehouse.SelectedItem != null) && (cbbxExportServiceCode.SelectedItem != null))
                {
                    string warehouseName = cbbxExportWarehouse.SelectedItem.Text;
                    string serviceCode = cbbxExportServiceCode.SelectedItem.Text;
                    string serviceName = cbbxExportServiceName.SelectedItem.Text;
                    int qty = (int)spinExportQty.Value;
                    string exportBy = txtExportBy.Text.Trim();
                    string note = txtExportNote.Text.Trim();
                    string series = txtSeri.Text.Trim();

                    if (exportBy == "")
                    {
                        MessageHandler.MessageManager(this, ErrorCode.FULFIllDATA_EXPORTBY);
                    }
                    else
                    {
                        Export export = null;
                        ErrorCode error = Program.Server.AddNewExport(warehouseName, serviceCode, qty, series, exportBy, note, out export);
                        MessageHandler.MessageManager(this, error);
                        if (error == ErrorCode.OK)
                        {
                            dtgExport.Rows.Add(new object[] { export.Id, serviceName, serviceCode, qty, exportBy, export.ExportAt, note, warehouseName });
                            PrepareForCreatingNewExport();
                            RefreshDataSourceForExporting();
                        }
                    }
                }
            }
            else if (sender.Equals(cbbxExportWarehouse))
            {
                RefreshDataSourceForExporting();
            }
        }
        #endregion

        #region method
        private void InitEvent()
        {
            btnAddSupplier.Click += Supplier_Click;
            btnUpdateSupplier.Click += Supplier_Click;
            btnDeleteSupplier.Click += Supplier_Click;
            dtgSupplier.Click += Supplier_Click;

            btnAddWarehouse.Click += Warehouse_Click;
            btnUpdateWarehouse.Click += Warehouse_Click;
            btnDeleteWarehouse.Click += Warehouse_Click;
            dtgWarehouse.Click += Warehouse_Click;

            btnImport.Click += Import_Click;
            cbbxImportWarehouse.SelectedIndexChanged += Import_Click;

            btnExport.Click += Export_Click;
            cbbxExportWarehouse.SelectedIndexChanged += Export_Click;
        }

        private void LoadData()
        {
            #region supplier
            List<Supplier> suppliers = Program.Server.GetSuppliers();
            for (int j = 0; j < suppliers.Count; j++)
            {
                dtgSupplier.Rows.Add(new object[] { suppliers[j].Id, 
                                                    suppliers[j].Name, 
                                                    suppliers[j].Code, 
                                                    suppliers[j].ContactPerson,
                                                    suppliers[j].Phone, 
                                                    suppliers[j].AccountNumber, 
                                                    suppliers[j].Address });
            }

            #endregion

            #region warehouse
            cbbxGoodsType.Items.Clear();
            cbbxGoodsType.Items.Add(ServiceType.Certificate.ToString());
            cbbxGoodsType.Items.Add(ServiceType.OtherService.ToString());
            cbbxGoodsType.Items[0].Value = ServiceType.Certificate;
            cbbxGoodsType.Items[1].Value = ServiceType.OtherService;

            for (int j = 0; j < cbbxGoodsType.Items.Count; j++)
            {
                cbbxGoodsType.Items[j].Font = new Font(this.Font.FontFamily, (float)9);
            }
            cbbxGoodsType.SelectedIndex = 0;

            List<Warehouse> warehouses = Program.Server.GetWarehouses();
            for (int j = 0; j < warehouses.Count; j++)
            {
                dtgWarehouse.Rows.Add(new object[] {warehouses[j].Id, 
                                                    warehouses[j].Name,
                                                    warehouses[j].Code, 
                                                    warehouses[j].WarehouseType.ToString() });
            }
            #endregion

            #region import
            List<Import> imports = Program.Server.GetImports();
            for (int j = 0; j < imports.Count; j++)
            {
                switch (imports[j].Warehouse.WarehouseType)
                {
                    case ServiceType.Certificate:
                        dtgImport.Rows.Add(new object[] { imports[j].Id,
                                                          imports[j].Certificate.Name, 
                                                          imports[j].Certificate.Code,
                                                          imports[j].Quantity, 
                                                          imports[j].ImportedBy, 
                                                          imports[j].ImportAt, 
                                                          imports[j].Note, 
                                                          imports[j].Warehouse.Name });
                        break;
                    case ServiceType.OtherService:
                        dtgImport.Rows.Add(new object[] { imports[j].Id,
                                                          imports[j].OtherService.Name, 
                                                          imports[j].OtherService.Code,
                                                          imports[j].Quantity, 
                                                          imports[j].ImportedBy, 
                                                          imports[j].ImportAt, 
                                                          imports[j].Note, 
                                                          imports[j].Warehouse.Name });
                        break;
                }

            }
            #endregion

            #region export
            List<Export> exports = Program.Server.GetExports();
            for (int j = 0; j < exports.Count; j++)
            {
                switch (exports[j].Warehouse.WarehouseType)
                {
                    case ServiceType.Certificate:
                        dtgExport.Rows.Add(new object[] { exports[j].Id,
                                                          exports[j].Certificate.Name, 
                                                          exports[j].Certificate.Code,
                                                          exports[j].Quantity, 
                                                          exports[j].ExportedBy, 
                                                          exports[j].ExportAt, 
                                                          exports[j].Note, 
                                                          exports[j].Warehouse.Name });
                        break;
                    case ServiceType.OtherService:
                        dtgExport.Rows.Add(new object[] { exports[j].Id,
                                                          exports[j].OtherService.Name, 
                                                          exports[j].OtherService.Code,
                                                          exports[j].Quantity, 
                                                          exports[j].ExportedBy, 
                                                          exports[j].ExportAt, 
                                                          exports[j].Note, 
                                                          exports[j].Warehouse.Name });
                        break;
                }

            }
            #endregion
        }

        private void RefreshDataSourceForExporting()
        {
            if (cbbxExportWarehouse.SelectedItem != null)
            {
                ServiceType type = (ServiceType)((DataRowView)((BindingSource)cbbxExportWarehouse.DataSource).Current)["Type"];
                string warehouseName = cbbxExportWarehouse.SelectedItem.Text;
                switch (type)
                {
                    case ServiceType.Certificate:
                        txtSeri.Enabled = true;
                        Dictionary<Certificate, int> certificates = Program.Server.GetCertificates(warehouseName);
                        DataTable tbl = new DataTable();
                        tbl.Columns.Add("Id", typeof(int));
                        tbl.Columns.Add("Name", typeof(string));
                        tbl.Columns.Add("Code", typeof(string));
                        tbl.Columns.Add("Qty", typeof(int));

                        foreach (Certificate cer in certificates.Keys)
                        {
                            tbl.Rows.Add(new object[] { cer.Id, cer.Name, cer.Code, certificates[cer] });
                        }

                        if (certificates.Count == 0)
                        {
                            PrepareForCreatingNewExport();
                        }

                        BindingSource bs = new BindingSource();
                        bs.DataSource = tbl;

                        cbbxExportServiceName.DataSource = bs;
                        cbbxExportServiceName.DisplayMember = "Name";
                        cbbxExportServiceCode.DataSource = bs;
                        cbbxExportServiceCode.DisplayMember = "Code";
                        lbAvailable.DataBindings.Clear();
                        lbAvailable.DataBindings.Add("Text", bs, "Qty");
                        spinExportQty.DataBindings.Clear();
                        spinExportQty.DataBindings.Add("Maximum", bs, "Qty");

                        break;
                    case ServiceType.OtherService:
                        txtSeri.Enabled = false;
                        Dictionary<OtherService, int> otherServices = Program.Server.GetOtherServices(warehouseName);
                        DataTable tbl1 = new DataTable();
                        tbl1.Columns.Add("Id", typeof(int));
                        tbl1.Columns.Add("Name", typeof(string));
                        tbl1.Columns.Add("Code", typeof(string));
                        tbl1.Columns.Add("Qty", typeof(int));
                        foreach (OtherService other in otherServices.Keys)
                        {
                            tbl1.Rows.Add(new object[] { other.Id, other.Name, other.Code, otherServices[other] });
                        }

                        if (otherServices.Count == 0)
                        {
                            PrepareForCreatingNewExport();
                        }

                        BindingSource bs1 = new BindingSource();
                        bs1.DataSource = tbl1;
                        cbbxExportServiceName.DataSource = bs1;
                        cbbxExportServiceName.DisplayMember = "Name";
                        cbbxExportServiceCode.DataSource = bs1;
                        cbbxExportServiceCode.DisplayMember = "Code";
                        lbAvailable.DataBindings.Clear();
                        lbAvailable.DataBindings.Add("Text", bs1, "Qty");
                        spinExportQty.DataBindings.Clear();
                        spinExportQty.DataBindings.Add("Maximum", bs1, "Qty");
                        break;
                }
            }
        }


        #endregion


    }
}
