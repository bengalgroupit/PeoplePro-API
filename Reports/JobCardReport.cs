// Decompiled with JetBrains decompiler
// Type: Hive.Reports.JobCardReport
// Assembly: Hive, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E73FBB45-C142-4356-94F4-2ADAD06710FA
// Assembly location: C:\Users\Jakir\Desktop\Hive\Hive.dll

using System.ComponentModel;
using System.Drawing;
using DevExpress.DataAccess.ObjectBinding;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.BarCode;
using DevExpress.XtraReports.UI;
using PeoplePro.ViewModels;

namespace PeoplePro.Reports;

public class JobCardReport : XtraReport
{
    private 
#nullable disable
        IContainer components;
    private TopMarginBand TopMargin;
    private BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private DetailBand Detail;
    private XRControlStyle Title;
    private XRControlStyle DetailCaption1;
    private XRControlStyle DetailData1;
    private XRControlStyle DetailData3_Odd;
    private XRControlStyle PageInfo;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel4;
    private XRLabel xrLabel5;
    private XRLabel xrLabel3;
    private XRLabel xrLabel7;
    private XRLabel xrLabel6;
    private XRLabel xrLabel8;
    private XRLabel xrLabel9;
    private XRLabel xrLabel10;
    private XRLabel xrLabel11;
    private XRLabel xrLabel12;
    private XRLabel xrLabel13;
    private XRLabel xrLabel14;
    private XRLabel xrLabel16;
    private XRLabel xrLabel15;
    private XRLabel xrLabel17;
    private XRLabel xrLabel23;
    private XRLabel xrLabel24;
    private XRLabel xrLabel25;
    private XRLabel xrLabel22;
    private XRLabel xrLabel20;
    private XRLabel xrLabel21;
    private XRLabel xrLabel19;
    private XRLabel xrLabel18;
    private XRLabel xrLabel26;
    private XRLabel xrLabel27;
    private XRLabel xrLabel28;
    private XRLabel xrLabel29;
    private XRLabel xrLabel30;
    private XRLabel xrLabel31;
    private XRLabel xrLabel32;
    private XRLabel xrLabel33;
    private ReportFooterBand ReportFooter;
    private XRLabel xrLabel42;
    private XRLabel xrLabel43;
    private XRLabel xrLabel44;
    private XRLabel xrLabel45;
    private XRLabel xrLabel46;
    private XRLabel xrLabel47;
    private XRLabel xrLabel48;
    private XRLabel xrLabel49;
    private XRLabel xrLabel34;
    private XRLabel xrLabel35;
    private XRLabel xrLabel36;
    private XRLabel xrLabel37;
    private XRLabel xrLabel38;
    private XRLabel xrLabel39;
    private XRLabel xrLabel40;
    private XRLabel xrLabel41;
    private XRLabel xrLabel50;
    private XRLabel xrLabel51;
    private XRLabel xrLabel52;
    private XRLabel xrLabel53;
    private PageFooterBand PageFooter;
    private ObjectDataSource objectDataSource2;
    private XRLabel xrLabel56;
    private XRLabel xrLabel55;
    private XRPageInfo xrPageInfo1;
    private PageHeaderBand PageHeader;
    private XRLabel xrLabel60;
    private XRLabel xrLabel61;
    private XRLabel xrLabel62;
    private XRLabel xrLabel63;
    private XRLabel xrLabel59;
    private XRLabel xrLabel54;
    private XRLabel xrLabel57;
    private XRLabel xrLabel58;
    private XRBarCode xrBarCode1;

    public JobCardReport() => InitializeComponent();

    private void xrLabel3_BeforePrint(
#nullable enable
        object sender, CancelEventArgs e)
    {
        var currentColumnValue = GetCurrentColumnValue("InTime") as string;
        xrLabel3.Text = currentColumnValue == "00:00" ? "-" : currentColumnValue;
    }

    private void xrLabel5_BeforePrint(object sender, CancelEventArgs e)
    {
        var currentColumnValue = GetCurrentColumnValue("OutTime") as string;
        xrLabel5.Text = currentColumnValue == "00:00" ? "-" : currentColumnValue;
    }

    private void xrLabel4_BeforePrint(object sender, CancelEventArgs e)
    {
        var int32 = Convert.ToInt32(GetCurrentColumnValue("LateMinutes"));
        xrLabel4.Text = int32 == 0 ? "-" : int32.ToString();
    }

    private void xrLabel6_BeforePrint(object sender, CancelEventArgs e)
    {
        var num = Convert.ToDecimal(GetCurrentColumnValue("OverTimeHours"));
        xrLabel6.Text = num == 0.00M ? "-" : num.ToString("F2");
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new Container();
        var qrCodeGenerator = new QRCodeGenerator();
        TopMargin = new TopMarginBand();
        BottomMargin = new BottomMarginBand();
        ReportHeader = new ReportHeaderBand();
        xrBarCode1 = new XRBarCode();
        xrLabel60 = new XRLabel();
        xrLabel61 = new XRLabel();
        xrLabel62 = new XRLabel();
        xrLabel63 = new XRLabel();
        xrLabel59 = new XRLabel();
        xrLabel54 = new XRLabel();
        xrLabel57 = new XRLabel();
        xrLabel58 = new XRLabel();
        xrLabel22 = new XRLabel();
        xrLabel23 = new XRLabel();
        xrLabel26 = new XRLabel();
        xrLabel27 = new XRLabel();
        xrLabel28 = new XRLabel();
        xrLabel29 = new XRLabel();
        xrLabel30 = new XRLabel();
        xrLabel31 = new XRLabel();
        xrLabel32 = new XRLabel();
        xrLabel33 = new XRLabel();
        xrLabel24 = new XRLabel();
        xrLabel25 = new XRLabel();
        xrLabel20 = new XRLabel();
        xrLabel21 = new XRLabel();
        xrLabel19 = new XRLabel();
        xrLabel18 = new XRLabel();
        xrLabel17 = new XRLabel();
        xrLabel16 = new XRLabel();
        xrLabel8 = new XRLabel();
        xrLabel9 = new XRLabel();
        xrLabel10 = new XRLabel();
        xrLabel11 = new XRLabel();
        xrLabel12 = new XRLabel();
        xrLabel13 = new XRLabel();
        xrLabel14 = new XRLabel();
        Detail = new DetailBand();
        xrLabel15 = new XRLabel();
        xrLabel7 = new XRLabel();
        xrLabel6 = new XRLabel();
        xrLabel4 = new XRLabel();
        xrLabel5 = new XRLabel();
        xrLabel3 = new XRLabel();
        xrLabel2 = new XRLabel();
        xrLabel1 = new XRLabel();
        Title = new XRControlStyle();
        DetailCaption1 = new XRControlStyle();
        DetailData1 = new XRControlStyle();
        DetailData3_Odd = new XRControlStyle();
        PageInfo = new XRControlStyle();
        ReportFooter = new ReportFooterBand();
        xrLabel52 = new XRLabel();
        xrLabel50 = new XRLabel();
        xrLabel51 = new XRLabel();
        xrLabel42 = new XRLabel();
        xrLabel43 = new XRLabel();
        xrLabel44 = new XRLabel();
        xrLabel45 = new XRLabel();
        xrLabel46 = new XRLabel();
        xrLabel47 = new XRLabel();
        xrLabel48 = new XRLabel();
        xrLabel49 = new XRLabel();
        xrLabel34 = new XRLabel();
        xrLabel35 = new XRLabel();
        xrLabel36 = new XRLabel();
        xrLabel37 = new XRLabel();
        xrLabel38 = new XRLabel();
        xrLabel39 = new XRLabel();
        xrLabel40 = new XRLabel();
        xrLabel41 = new XRLabel();
        xrLabel53 = new XRLabel();
        PageFooter = new PageFooterBand();
        xrPageInfo1 = new XRPageInfo();
        xrLabel56 = new XRLabel();
        xrLabel55 = new XRLabel();
        objectDataSource2 = new ObjectDataSource(components);
        PageHeader = new PageHeaderBand();
        objectDataSource2.BeginInit();
        BeginInit();
        TopMargin.HeightF = 32.29167f;
        TopMargin.Name = "TopMargin";
        BottomMargin.HeightF = 36.66636f;
        BottomMargin.Name = "BottomMargin";
        ReportHeader.Controls.AddRange(new XRControl[26]
        {
            xrBarCode1,
            xrLabel60,
            xrLabel61,
            xrLabel62,
            xrLabel63,
            xrLabel59,
            xrLabel54,
            xrLabel57,
            xrLabel58,
            xrLabel22,
            xrLabel23,
            xrLabel26,
            xrLabel27,
            xrLabel28,
            xrLabel29,
            xrLabel30,
            xrLabel31,
            xrLabel32,
            xrLabel33,
            xrLabel24,
            xrLabel25,
            xrLabel20,
            xrLabel21,
            xrLabel19,
            xrLabel18,
            xrLabel17
        });
        ReportHeader.HeightF = 160.7499f;
        ReportHeader.Name = "ReportHeader";
        xrBarCode1.ExpressionBindings.AddRange(new ExpressionBinding[1]
        {
            new ExpressionBinding("BeforePrint", "Text", "Now()")
        });
        xrBarCode1.LocationFloat = new PointFloat(660f, 0.0f);
        xrBarCode1.Name = "xrBarCode1";
        xrBarCode1.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
        xrBarCode1.ShowText = false;
        xrBarCode1.SizeF = new SizeF(46f, 46f);
        xrBarCode1.StylePriority.UsePadding = false;
        xrBarCode1.Symbology = qrCodeGenerator;
        xrBarCode1.TextFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}";
        xrLabel60.BorderColor = Color.LightGray;
        xrLabel60.Borders = BorderSide.None;
        xrLabel60.Font = new DXFont("Tahoma", 9f);
        xrLabel60.LocationFloat = new PointFloat(464.5207f, 50.62499f);
        xrLabel60.Multiline = true;
        xrLabel60.Name = "xrLabel60";
        xrLabel60.SizeF = new SizeF(10.81226f, 22.99998f);
        xrLabel60.StylePriority.UseBorderColor = false;
        xrLabel60.StylePriority.UseBorders = false;
        xrLabel60.StylePriority.UseFont = false;
        xrLabel60.StylePriority.UsePadding = false;
        xrLabel60.StylePriority.UseTextAlignment = false;
        xrLabel60.Text = ":";
        xrLabel60.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel60.TextFormatString = "{0:dd/MM/yyyy}";
        xrLabel61.BorderColor = Color.LightGray;
        xrLabel61.Borders = BorderSide.None;
        xrLabel61.Font = new DXFont("Tahoma", 9f);
        xrLabel61.LocationFloat = new PointFloat(464.5207f, 73.62512f);
        xrLabel61.Multiline = true;
        xrLabel61.Name = "xrLabel61";
        xrLabel61.SizeF = new SizeF(10.81226f, 23f);
        xrLabel61.StylePriority.UseBorderColor = false;
        xrLabel61.StylePriority.UseBorders = false;
        xrLabel61.StylePriority.UseFont = false;
        xrLabel61.StylePriority.UsePadding = false;
        xrLabel61.StylePriority.UseTextAlignment = false;
        xrLabel61.Text = ":";
        xrLabel61.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel61.TextFormatString = "{0:dd/MM/yyyy}";
        xrLabel62.BorderColor = Color.LightGray;
        xrLabel62.Borders = BorderSide.None;
        xrLabel62.Font = new DXFont("Tahoma", 9f);
        xrLabel62.LocationFloat = new PointFloat(464.5207f, 96.62505f);
        xrLabel62.Multiline = true;
        xrLabel62.Name = "xrLabel62";
        xrLabel62.SizeF = new SizeF(10.81226f, 22.99998f);
        xrLabel62.StylePriority.UseBorderColor = false;
        xrLabel62.StylePriority.UseBorders = false;
        xrLabel62.StylePriority.UseFont = false;
        xrLabel62.StylePriority.UsePadding = false;
        xrLabel62.StylePriority.UseTextAlignment = false;
        xrLabel62.Text = ":";
        xrLabel62.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel62.TextFormatString = "{0:dd/MM/yyyy}";
        xrLabel63.BorderColor = Color.LightGray;
        xrLabel63.Borders = BorderSide.None;
        xrLabel63.Font = new DXFont("Tahoma", 9f);
        xrLabel63.LocationFloat = new PointFloat(464.5207f, 119.6249f);
        xrLabel63.Multiline = true;
        xrLabel63.Name = "xrLabel63";
        xrLabel63.SizeF = new SizeF(10.81226f, 22.99998f);
        xrLabel63.StylePriority.UseBorderColor = false;
        xrLabel63.StylePriority.UseBorders = false;
        xrLabel63.StylePriority.UseFont = false;
        xrLabel63.StylePriority.UsePadding = false;
        xrLabel63.StylePriority.UseTextAlignment = false;
        xrLabel63.Text = ":";
        xrLabel63.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel63.TextFormatString = "{0:dd/MM/yyyy}";
        xrLabel59.BorderColor = Color.LightGray;
        xrLabel59.Borders = BorderSide.None;
        xrLabel59.Font = new DXFont("Tahoma", 9f);
        xrLabel59.LocationFloat = new PointFloat(98.00002f, 119.6249f);
        xrLabel59.Multiline = true;
        xrLabel59.Name = "xrLabel59";
        xrLabel59.SizeF = new SizeF(10.81226f, 22.99998f);
        xrLabel59.StylePriority.UseBorderColor = false;
        xrLabel59.StylePriority.UseBorders = false;
        xrLabel59.StylePriority.UseFont = false;
        xrLabel59.StylePriority.UsePadding = false;
        xrLabel59.StylePriority.UseTextAlignment = false;
        xrLabel59.Text = ":";
        xrLabel59.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel59.TextFormatString = "{0:dd/MM/yyyy}";
        xrLabel54.BorderColor = Color.LightGray;
        xrLabel54.Borders = BorderSide.None;
        xrLabel54.Font = new DXFont("Tahoma", 9f);
        xrLabel54.LocationFloat = new PointFloat(98.00005f, 96.62502f);
        xrLabel54.Multiline = true;
        xrLabel54.Name = "xrLabel54";
        xrLabel54.SizeF = new SizeF(10.81226f, 22.99998f);
        xrLabel54.StylePriority.UseBorderColor = false;
        xrLabel54.StylePriority.UseBorders = false;
        xrLabel54.StylePriority.UseFont = false;
        xrLabel54.StylePriority.UsePadding = false;
        xrLabel54.StylePriority.UseTextAlignment = false;
        xrLabel54.Text = ":";
        xrLabel54.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel54.TextFormatString = "{0:dd/MM/yyyy}";
        xrLabel57.BorderColor = Color.LightGray;
        xrLabel57.Borders = BorderSide.None;
        xrLabel57.Font = new DXFont("Tahoma", 9f);
        xrLabel57.LocationFloat = new PointFloat(98.00005f, 73.62509f);
        xrLabel57.Multiline = true;
        xrLabel57.Name = "xrLabel57";
        xrLabel57.SizeF = new SizeF(10.81226f, 23f);
        xrLabel57.StylePriority.UseBorderColor = false;
        xrLabel57.StylePriority.UseBorders = false;
        xrLabel57.StylePriority.UseFont = false;
        xrLabel57.StylePriority.UsePadding = false;
        xrLabel57.StylePriority.UseTextAlignment = false;
        xrLabel57.Text = ":";
        xrLabel57.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel57.TextFormatString = "{0:dd/MM/yyyy}";
        xrLabel58.BorderColor = Color.LightGray;
        xrLabel58.Borders = BorderSide.None;
        xrLabel58.Font = new DXFont("Tahoma", 9f);
        xrLabel58.LocationFloat = new PointFloat(98.00005f, 50.62498f);
        xrLabel58.Multiline = true;
        xrLabel58.Name = "xrLabel58";
        xrLabel58.SizeF = new SizeF(10.81226f, 22.99998f);
        xrLabel58.StylePriority.UseBorderColor = false;
        xrLabel58.StylePriority.UseBorders = false;
        xrLabel58.StylePriority.UseFont = false;
        xrLabel58.StylePriority.UsePadding = false;
        xrLabel58.StylePriority.UseTextAlignment = false;
        xrLabel58.Text = ":";
        xrLabel58.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel58.TextFormatString = "{0:dd/MM/yyyy}";
        xrLabel22.BorderColor = Color.LightGray;
        xrLabel22.Borders = BorderSide.None;
        xrLabel22.Font = new DXFont("Tahoma", 9f);
        xrLabel22.LocationFloat = new PointFloat(343.8334f, 73.62495f);
        xrLabel22.Multiline = true;
        xrLabel22.Name = "xrLabel22";
        xrLabel22.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
        xrLabel22.SizeF = new SizeF(120f, 23f);
        xrLabel22.StylePriority.UseBorderColor = false;
        xrLabel22.StylePriority.UseBorders = false;
        xrLabel22.StylePriority.UseFont = false;
        xrLabel22.StylePriority.UsePadding = false;
        xrLabel22.StylePriority.UseTextAlignment = false;
        xrLabel22.Text = "Job Title";
        xrLabel22.TextAlignment = TextAlignment.MiddleLeft;
        xrLabel22.TextFormatString = "{0:dd/MM/yyyy}";
        xrLabel23.BorderColor = Color.LightGray;
        xrLabel23.Borders = BorderSide.None;
        xrLabel23.ExpressionBindings.AddRange(new ExpressionBinding[1]
        {
            new ExpressionBinding("BeforePrint", "Text", "[JobTitle]")
        });
        xrLabel23.Font = new DXFont("Tahoma", 9f);
        xrLabel23.LocationFloat = new PointFloat(475.3332f, 73.62497f);
        xrLabel23.Multiline = true;
        xrLabel23.Name = "xrLabel23";
        xrLabel23.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
        xrLabel23.SizeF = new SizeF(230.667f, 23f);
        xrLabel23.StylePriority.UseBorderColor = false;
        xrLabel23.StylePriority.UseBorders = false;
        xrLabel23.StylePriority.UseFont = false;
        xrLabel23.StylePriority.UsePadding = false;
        xrLabel23.StylePriority.UseTextAlignment = false;
        xrLabel23.Text = "Team Lead (Software Development)";
        xrLabel23.TextAlignment = TextAlignment.MiddleLeft;
        xrLabel23.TextFormatString = "{0:dd/MM/yyyy}";
        xrLabel26.BorderColor = Color.LightGray;
        xrLabel26.Borders = BorderSide.None;
        xrLabel26.Font = new DXFont("Tahoma", 9f);
        xrLabel26.LocationFloat = new PointFloat(343.8334f, 50.62495f);
        xrLabel26.Multiline = true;
        xrLabel26.Name = "xrLabel26";
        xrLabel26.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
        xrLabel26.SizeF = new SizeF(120f, 23f);
        xrLabel26.StylePriority.UseBorderColor = false;
        xrLabel26.StylePriority.UseBorders = false;
        xrLabel26.StylePriority.UseFont = false;
        xrLabel26.StylePriority.UsePadding = false;
        xrLabel26.StylePriority.UseTextAlignment = false;
        xrLabel26.Text = "Period";
        xrLabel26.TextAlignment = TextAlignment.MiddleLeft;
        xrLabel26.TextFormatString = "{0:dd/MM/yyyy}";
        xrLabel27.BorderColor = Color.LightGray;
        xrLabel27.Borders = BorderSide.None;
        xrLabel27.ExpressionBindings.AddRange(new ExpressionBinding[1]
        {
            new ExpressionBinding("BeforePrint", "Text", "[Period]")
        });
        xrLabel27.Font = new DXFont("Tahoma", 9f);
        xrLabel27.LocationFloat = new PointFloat(475.333f, 50.62495f);
        xrLabel27.Multiline = true;
        xrLabel27.Name = "xrLabel27";
        xrLabel27.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
        xrLabel27.SizeF = new SizeF(230.667f, 23f);
        xrLabel27.StylePriority.UseBorderColor = false;
        xrLabel27.StylePriority.UseBorders = false;
        xrLabel27.StylePriority.UseFont = false;
        xrLabel27.StylePriority.UsePadding = false;
        xrLabel27.StylePriority.UseTextAlignment = false;
        xrLabel27.Text = "01/01/2024 to 13/01/2024";
        xrLabel27.TextAlignment = TextAlignment.MiddleLeft;
        xrLabel27.TextFormatString = "{0:dd/MM/yyyy}";
        xrLabel28.BorderColor = Color.LightGray;
        xrLabel28.Borders = BorderSide.None;
        xrLabel28.ExpressionBindings.AddRange(new ExpressionBinding[1]
        {
            new ExpressionBinding("BeforePrint", "Text", "[Company]")
        });
        xrLabel28.Font = new DXFont("Tahoma", 9f);
        xrLabel28.LocationFloat = new PointFloat(475.333f, 96.62496f);
        xrLabel28.Multiline = true;
        xrLabel28.Name = "xrLabel28";
        xrLabel28.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
        xrLabel28.SizeF = new SizeF(230.667f, 23f);
        xrLabel28.StylePriority.UseBorderColor = false;
        xrLabel28.StylePriority.UseBorders = false;
        xrLabel28.StylePriority.UseFont = false;
        xrLabel28.StylePriority.UsePadding = false;
        xrLabel28.StylePriority.UseTextAlignment = false;
        xrLabel28.Text = "Bengal Plastics Ltd.";
        xrLabel28.TextAlignment = TextAlignment.MiddleLeft;
        xrLabel28.TextFormatString = "{0:dd/MM/yyyy}";
        xrLabel29.BorderColor = Color.LightGray;
        xrLabel29.Borders = BorderSide.None;
        xrLabel29.Font = new DXFont("Tahoma", 9f);
        xrLabel29.LocationFloat = new PointFloat(343.8334f, 96.62498f);
        xrLabel29.Multiline = true;
        xrLabel29.Name = "xrLabel29";
        xrLabel29.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
        xrLabel29.SizeF = new SizeF(120f, 23f);
        xrLabel29.StylePriority.UseBorderColor = false;
        xrLabel29.StylePriority.UseBorders = false;
        xrLabel29.StylePriority.UseFont = false;
        xrLabel29.StylePriority.UsePadding = false;
        xrLabel29.StylePriority.UseTextAlignment = false;
        xrLabel29.Text = "Company";
        xrLabel29.TextAlignment = TextAlignment.MiddleLeft;
        xrLabel29.TextFormatString = "{0:dd/MM/yyyy}";
        xrLabel30.BorderColor = Color.LightGray;
        xrLabel30.Borders = BorderSide.None;
        xrLabel30.Font = new DXFont("Tahoma", 9f);
        xrLabel30.LocationFloat = new PointFloat(343.8334f, 119.6249f);
        xrLabel30.Multiline = true;
        xrLabel30.Name = "xrLabel30";
        xrLabel30.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
        xrLabel30.SizeF = new SizeF(120f, 22.99999f);
        xrLabel30.StylePriority.UseBorderColor = false;
        xrLabel30.StylePriority.UseBorders = false;
        xrLabel30.StylePriority.UseFont = false;
        xrLabel30.StylePriority.UsePadding = false;
        xrLabel30.StylePriority.UseTextAlignment = false;
        xrLabel30.Text = "Operating Location";
        xrLabel30.TextAlignment = TextAlignment.MiddleLeft;
        xrLabel30.TextFormatString = "{0:dd/MM/yyyy}";
        xrLabel31.BorderColor = Color.LightGray;
        xrLabel31.Borders = BorderSide.None;
        xrLabel31.ExpressionBindings.AddRange(new ExpressionBinding[1]
        {
            new ExpressionBinding("BeforePrint", "Text", "[Department]")
        });
        xrLabel31.Font = new DXFont("Tahoma", 9f);
        xrLabel31.LocationFloat = new PointFloat(109.125f, 96.62498f);
        xrLabel31.Multiline = true;
        xrLabel31.Name = "xrLabel31";
        xrLabel31.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
        xrLabel31.SizeF = new SizeF(226.2916f, 22.99999f);
        xrLabel31.StylePriority.UseBorderColor = false;
        xrLabel31.StylePriority.UseBorders = false;
        xrLabel31.StylePriority.UseFont = false;
        xrLabel31.StylePriority.UsePadding = false;
        xrLabel31.StylePriority.UseTextAlignment = false;
        xrLabel31.Text = "Information Technology";
        xrLabel31.TextAlignment = TextAlignment.MiddleLeft;
        xrLabel31.TextFormatString = "{0:dd/MM/yyyy}";
        xrLabel32.BorderColor = Color.LightGray;
        xrLabel32.Borders = BorderSide.None;
        xrLabel32.Font = new DXFont("Tahoma", 9f);
        xrLabel32.LocationFloat = new PointFloat(3.178914E-05f, 96.62498f);
        xrLabel32.Multiline = true;
        xrLabel32.Name = "xrLabel32";
        xrLabel32.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
        xrLabel32.SizeF = new SizeF(98.00003f, 22.99999f);
        xrLabel32.StylePriority.UseBorderColor = false;
        xrLabel32.StylePriority.UseBorders = false;
        xrLabel32.StylePriority.UseFont = false;
        xrLabel32.StylePriority.UsePadding = false;
        xrLabel32.StylePriority.UseTextAlignment = false;
        xrLabel32.Text = "Department";
        xrLabel32.TextAlignment = TextAlignment.MiddleLeft;
        xrLabel32.TextFormatString = "{0:dd/MM/yyyy}";
        xrLabel33.BorderColor = Color.LightGray;
        xrLabel33.Borders = BorderSide.None;
        xrLabel33.ExpressionBindings.AddRange(new ExpressionBinding[1]
        {
            new ExpressionBinding("BeforePrint", "Text", "[OpLocation]")
        });
        xrLabel33.Font = new DXFont("Tahoma", 9f);
        xrLabel33.LocationFloat = new PointFloat(475.333f, 119.625f);
        xrLabel33.Multiline = true;
        xrLabel33.Name = "xrLabel33";
        xrLabel33.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
        xrLabel33.SizeF = new SizeF(230.667f, 22.99999f);
        xrLabel33.StylePriority.UseBorderColor = false;
        xrLabel33.StylePriority.UseBorders = false;
        xrLabel33.StylePriority.UseFont = false;
        xrLabel33.StylePriority.UsePadding = false;
        xrLabel33.StylePriority.UseTextAlignment = false;
        xrLabel33.Text = "Corporate Head Office";
        xrLabel33.TextAlignment = TextAlignment.MiddleLeft;
        xrLabel33.TextFormatString = "{0:dd/MM/yyyy}";
        xrLabel24.BorderColor = Color.LightGray;
        xrLabel24.Borders = BorderSide.None;
        xrLabel24.Font = new DXFont("Tahoma", 9f);
        xrLabel24.LocationFloat = new PointFloat(0.0f, 119.625f);
        xrLabel24.Multiline = true;
        xrLabel24.Name = "xrLabel24";
        xrLabel24.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
        xrLabel24.SizeF = new SizeF(98.00002f, 23f);
        xrLabel24.StylePriority.UseBorderColor = false;
        xrLabel24.StylePriority.UseBorders = false;
        xrLabel24.StylePriority.UseFont = false;
        xrLabel24.StylePriority.UsePadding = false;
        xrLabel24.StylePriority.UseTextAlignment = false;
        xrLabel24.Text = "Section";
        xrLabel24.TextAlignment = TextAlignment.MiddleLeft;
        xrLabel24.TextFormatString = "{0:dd/MM/yyyy}";
        xrLabel25.BorderColor = Color.LightGray;
        xrLabel25.Borders = BorderSide.None;
        xrLabel25.ExpressionBindings.AddRange(new ExpressionBinding[1]
        {
            new ExpressionBinding("BeforePrint", "Text", "[Section]")
        });
        xrLabel25.Font = new DXFont("Tahoma", 9f);
        xrLabel25.LocationFloat = new PointFloat(109.125f, 119.625f);
        xrLabel25.Multiline = true;
        xrLabel25.Name = "xrLabel25";
        xrLabel25.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
        xrLabel25.SizeF = new SizeF(226.2916f, 22.99998f);
        xrLabel25.StylePriority.UseBorderColor = false;
        xrLabel25.StylePriority.UseBorders = false;
        xrLabel25.StylePriority.UseFont = false;
        xrLabel25.StylePriority.UsePadding = false;
        xrLabel25.StylePriority.UseTextAlignment = false;
        xrLabel25.Text = "Programming";
        xrLabel25.TextAlignment = TextAlignment.MiddleLeft;
        xrLabel25.TextFormatString = "{0:dd/MM/yyyy}";
        xrLabel20.BorderColor = Color.LightGray;
        xrLabel20.Borders = BorderSide.None;
        xrLabel20.Font = new DXFont("Tahoma", 9f);
        xrLabel20.LocationFloat = new PointFloat(0.0f, 73.62495f);
        xrLabel20.Multiline = true;
        xrLabel20.Name = "xrLabel20";
        xrLabel20.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
        xrLabel20.SizeF = new SizeF(98.00002f, 23f);
        xrLabel20.StylePriority.UseBorderColor = false;
        xrLabel20.StylePriority.UseBorders = false;
        xrLabel20.StylePriority.UseFont = false;
        xrLabel20.StylePriority.UsePadding = false;
        xrLabel20.StylePriority.UseTextAlignment = false;
        xrLabel20.Text = "Name";
        xrLabel20.TextAlignment = TextAlignment.MiddleLeft;
        xrLabel20.TextFormatString = "{0:dd/MM/yyyy}";
        xrLabel21.BorderColor = Color.LightGray;
        xrLabel21.Borders = BorderSide.None;
        xrLabel21.ExpressionBindings.AddRange(new ExpressionBinding[1]
        {
            new ExpressionBinding("BeforePrint", "Text", "[Name]")
        });
        xrLabel21.Font = new DXFont("Tahoma", 9f);
        xrLabel21.LocationFloat = new PointFloat(109.125f, 73.62495f);
        xrLabel21.Multiline = true;
        xrLabel21.Name = "xrLabel21";
        xrLabel21.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
        xrLabel21.SizeF = new SizeF(226.2916f, 23f);
        xrLabel21.StylePriority.UseBorderColor = false;
        xrLabel21.StylePriority.UseBorders = false;
        xrLabel21.StylePriority.UseFont = false;
        xrLabel21.StylePriority.UsePadding = false;
        xrLabel21.StylePriority.UseTextAlignment = false;
        xrLabel21.Text = "Jakir Hossain";
        xrLabel21.TextAlignment = TextAlignment.MiddleLeft;
        xrLabel21.TextFormatString = "{0:dd/MM/yyyy}";
        xrLabel19.BorderColor = Color.LightGray;
        xrLabel19.Borders = BorderSide.None;
        xrLabel19.ExpressionBindings.AddRange(new ExpressionBinding[1]
        {
            new ExpressionBinding("BeforePrint", "Text", "[EmpCode]")
        });
        xrLabel19.Font = new DXFont("Tahoma", 9f);
        xrLabel19.LocationFloat = new PointFloat(109.125f, 50.62495f);
        xrLabel19.Multiline = true;
        xrLabel19.Name = "xrLabel19";
        xrLabel19.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
        xrLabel19.SizeF = new SizeF(226.2916f, 23f);
        xrLabel19.StylePriority.UseBorderColor = false;
        xrLabel19.StylePriority.UseBorders = false;
        xrLabel19.StylePriority.UseFont = false;
        xrLabel19.StylePriority.UsePadding = false;
        xrLabel19.StylePriority.UseTextAlignment = false;
        xrLabel19.Text = "047785";
        xrLabel19.TextAlignment = TextAlignment.MiddleLeft;
        xrLabel19.TextFormatString = "{0:dd/MM/yyyy}";
        xrLabel18.BorderColor = Color.LightGray;
        xrLabel18.Borders = BorderSide.None;
        xrLabel18.Font = new DXFont("Tahoma", 9f);
        xrLabel18.LocationFloat = new PointFloat(0.0f, 50.62495f);
        xrLabel18.Multiline = true;
        xrLabel18.Name = "xrLabel18";
        xrLabel18.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
        xrLabel18.SizeF = new SizeF(98f, 23f);
        xrLabel18.StylePriority.UseBorderColor = false;
        xrLabel18.StylePriority.UseBorders = false;
        xrLabel18.StylePriority.UseFont = false;
        xrLabel18.StylePriority.UsePadding = false;
        xrLabel18.StylePriority.UseTextAlignment = false;
        xrLabel18.Text = "Employee Code";
        xrLabel18.TextAlignment = TextAlignment.MiddleLeft;
        xrLabel18.TextFormatString = "{0:dd/MM/yyyy}";
        xrLabel17.Font = new DXFont("Tahoma", 12f, DXFontStyle.Bold);
        xrLabel17.ForeColor = Color.FromArgb(64, 64, 64);
        xrLabel17.LocationFloat = new PointFloat(234.125f, 6f);
        xrLabel17.Multiline = true;
        xrLabel17.Name = "xrLabel17";
        xrLabel17.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel17.SizeF = new SizeF(230.2083f, 23f);
        xrLabel17.StylePriority.UseFont = false;
        xrLabel17.StylePriority.UseForeColor = false;
        xrLabel17.StylePriority.UseTextAlignment = false;
        xrLabel17.Text = "ATTENDANCE CARD";
        xrLabel17.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel16.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel16.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Bottom;
        xrLabel16.Font = new DXFont("Tahoma", 9f);
        xrLabel16.ForeColor = Color.Black;
        xrLabel16.LocationFloat = new PointFloat(178.7082f, 0.0f);
        xrLabel16.Multiline = true;
        xrLabel16.Name = "xrLabel16";
        xrLabel16.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel16.SizeF = new SizeF(57.29164f, 23f);
        xrLabel16.StylePriority.UseBorderColor = false;
        xrLabel16.StylePriority.UseBorders = false;
        xrLabel16.StylePriority.UseFont = false;
        xrLabel16.StylePriority.UseForeColor = false;
        xrLabel16.StylePriority.UseTextAlignment = false;
        xrLabel16.Text = "Status";
        xrLabel16.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel8.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel8.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Bottom;
        xrLabel8.Font = new DXFont("Tahoma", 9f);
        xrLabel8.ForeColor = Color.Black;
        xrLabel8.LocationFloat = new PointFloat(3.178914E-05f, 0.0f);
        xrLabel8.Multiline = true;
        xrLabel8.Name = "xrLabel8";
        xrLabel8.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel8.SizeF = new SizeF(92.70834f, 23f);
        xrLabel8.StylePriority.UseBorderColor = false;
        xrLabel8.StylePriority.UseBorders = false;
        xrLabel8.StylePriority.UseFont = false;
        xrLabel8.StylePriority.UseForeColor = false;
        xrLabel8.StylePriority.UseTextAlignment = false;
        xrLabel8.Text = "Attend Date";
        xrLabel8.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel8.TextFormatString = "{0:dd/MM/yyyy}";
        xrLabel9.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel9.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Bottom;
        xrLabel9.Font = new DXFont("Tahoma", 9f);
        xrLabel9.ForeColor = Color.Black;
        xrLabel9.LocationFloat = new PointFloat(92.7084f, 0.0f);
        xrLabel9.Multiline = true;
        xrLabel9.Name = "xrLabel9";
        xrLabel9.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel9.SizeF = new SizeF(85.99981f, 23f);
        xrLabel9.StylePriority.UseBorderColor = false;
        xrLabel9.StylePriority.UseBorders = false;
        xrLabel9.StylePriority.UseFont = false;
        xrLabel9.StylePriority.UseForeColor = false;
        xrLabel9.StylePriority.UseTextAlignment = false;
        xrLabel9.Text = "Day";
        xrLabel9.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel10.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel10.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Bottom;
        xrLabel10.Font = new DXFont("Tahoma", 9f);
        xrLabel10.ForeColor = Color.Black;
        xrLabel10.LocationFloat = new PointFloat(235.9999f, 0.0f);
        xrLabel10.Multiline = true;
        xrLabel10.Name = "xrLabel10";
        xrLabel10.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel10.SizeF = new SizeF(84.37497f, 23f);
        xrLabel10.StylePriority.UseBorderColor = false;
        xrLabel10.StylePriority.UseBorders = false;
        xrLabel10.StylePriority.UseFont = false;
        xrLabel10.StylePriority.UseForeColor = false;
        xrLabel10.StylePriority.UseTextAlignment = false;
        xrLabel10.Text = "Entry Time";
        xrLabel10.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel11.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel11.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Bottom;
        xrLabel11.Font = new DXFont("Tahoma", 9f);
        xrLabel11.ForeColor = Color.Black;
        xrLabel11.LocationFloat = new PointFloat(320.3748f, 0.0f);
        xrLabel11.Multiline = true;
        xrLabel11.Name = "xrLabel11";
        xrLabel11.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel11.SizeF = new SizeF(77.08334f, 23f);
        xrLabel11.StylePriority.UseBorderColor = false;
        xrLabel11.StylePriority.UseBorders = false;
        xrLabel11.StylePriority.UseFont = false;
        xrLabel11.StylePriority.UseForeColor = false;
        xrLabel11.StylePriority.UseTextAlignment = false;
        xrLabel11.Text = "Exit Time";
        xrLabel11.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel11.TextFormatString = "{0:dd/MM/yyyy}";
        xrLabel12.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel12.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Bottom;
        xrLabel12.Font = new DXFont("Tahoma", 9f);
        xrLabel12.ForeColor = Color.Black;
        xrLabel12.LocationFloat = new PointFloat(397.4582f, 0.0f);
        xrLabel12.Multiline = true;
        xrLabel12.Name = "xrLabel12";
        xrLabel12.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel12.SizeF = new SizeF(71.875f, 23f);
        xrLabel12.StylePriority.UseBorderColor = false;
        xrLabel12.StylePriority.UseBorders = false;
        xrLabel12.StylePriority.UseFont = false;
        xrLabel12.StylePriority.UseForeColor = false;
        xrLabel12.StylePriority.UseTextAlignment = false;
        xrLabel12.Text = "Late (Min)";
        xrLabel12.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel13.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel13.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Bottom;
        xrLabel13.Font = new DXFont("Tahoma", 9f);
        xrLabel13.ForeColor = Color.Black;
        xrLabel13.LocationFloat = new PointFloat(469.3332f, 0.0f);
        xrLabel13.Multiline = true;
        xrLabel13.Name = "xrLabel13";
        xrLabel13.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel13.SizeF = new SizeF(100.0002f, 23f);
        xrLabel13.StylePriority.UseBorderColor = false;
        xrLabel13.StylePriority.UseBorders = false;
        xrLabel13.StylePriority.UseFont = false;
        xrLabel13.StylePriority.UseForeColor = false;
        xrLabel13.StylePriority.UseTextAlignment = false;
        xrLabel13.Text = "Overtime (Hr)";
        xrLabel13.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel14.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel14.Borders = BorderSide.All;
        xrLabel14.Font = new DXFont("Tahoma", 9f);
        xrLabel14.ForeColor = Color.Black;
        xrLabel14.LocationFloat = new PointFloat(569.3334f, 0.0f);
        xrLabel14.Multiline = true;
        xrLabel14.Name = "xrLabel14";
        xrLabel14.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel14.SizeF = new SizeF(136.6666f, 23f);
        xrLabel14.StylePriority.UseBorderColor = false;
        xrLabel14.StylePriority.UseBorders = false;
        xrLabel14.StylePriority.UseFont = false;
        xrLabel14.StylePriority.UseForeColor = false;
        xrLabel14.StylePriority.UseTextAlignment = false;
        xrLabel14.Text = "Remarks";
        xrLabel14.TextAlignment = TextAlignment.MiddleCenter;
        Detail.Controls.AddRange(new XRControl[8]
        {
            xrLabel15,
            xrLabel7,
            xrLabel6,
            xrLabel4,
            xrLabel5,
            xrLabel3,
            xrLabel2,
            xrLabel1
        });
        Detail.HeightF = 23f;
        Detail.Name = "Detail";
        xrLabel15.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel15.Borders = BorderSide.Left | BorderSide.Bottom;
        xrLabel15.ExpressionBindings.AddRange(new ExpressionBinding[1]
        {
            new ExpressionBinding("BeforePrint", "Text", "[Status]")
        });
        xrLabel15.Font = new DXFont("Tahoma", 9f);
        xrLabel15.LocationFloat = new PointFloat(178.7082f, 0.0f);
        xrLabel15.Multiline = true;
        xrLabel15.Name = "xrLabel15";
        xrLabel15.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel15.SizeF = new SizeF(57.29167f, 23f);
        xrLabel15.StylePriority.UseBorderColor = false;
        xrLabel15.StylePriority.UseBorders = false;
        xrLabel15.StylePriority.UseFont = false;
        xrLabel15.StylePriority.UseTextAlignment = false;
        xrLabel15.Text = "xrLabel1";
        xrLabel15.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel7.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel7.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
        xrLabel7.ExpressionBindings.AddRange(new ExpressionBinding[1]
        {
            new ExpressionBinding("BeforePrint", "Text", "[Remarks]")
        });
        xrLabel7.Font = new DXFont("Tahoma", 9f);
        xrLabel7.LocationFloat = new PointFloat(569.3334f, 0.0f);
        xrLabel7.Multiline = true;
        xrLabel7.Name = "xrLabel7";
        xrLabel7.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel7.SizeF = new SizeF(136.6666f, 23f);
        xrLabel7.StylePriority.UseBorderColor = false;
        xrLabel7.StylePriority.UseBorders = false;
        xrLabel7.StylePriority.UseFont = false;
        xrLabel7.StylePriority.UseTextAlignment = false;
        xrLabel7.Text = "xrLabel1";
        xrLabel7.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel7.TextTrimming = DXStringTrimming.EllipsisCharacter;
        xrLabel7.WordWrap = false;
        xrLabel6.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel6.Borders = BorderSide.Left | BorderSide.Bottom;
        xrLabel6.ExpressionBindings.AddRange(new ExpressionBinding[1]
        {
            new ExpressionBinding("BeforePrint", "Text", "[OverTimeHours]")
        });
        xrLabel6.Font = new DXFont("Tahoma", 9f);
        xrLabel6.LocationFloat = new PointFloat(469.3332f, 0.0f);
        xrLabel6.Multiline = true;
        xrLabel6.Name = "xrLabel6";
        xrLabel6.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel6.SizeF = new SizeF(100.0002f, 23f);
        xrLabel6.StylePriority.UseBorderColor = false;
        xrLabel6.StylePriority.UseBorders = false;
        xrLabel6.StylePriority.UseFont = false;
        xrLabel6.StylePriority.UseTextAlignment = false;
        xrLabel6.Text = "xrLabel1";
        xrLabel6.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel6.BeforePrint += new BeforePrintEventHandler(xrLabel6_BeforePrint);
        xrLabel4.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel4.Borders = BorderSide.Left | BorderSide.Bottom;
        xrLabel4.ExpressionBindings.AddRange(new ExpressionBinding[1]
        {
            new ExpressionBinding("BeforePrint", "Text", "[LateMinutes]")
        });
        xrLabel4.Font = new DXFont("Tahoma", 9f);
        xrLabel4.LocationFloat = new PointFloat(397.4582f, 0.0f);
        xrLabel4.Multiline = true;
        xrLabel4.Name = "xrLabel4";
        xrLabel4.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel4.SizeF = new SizeF(71.875f, 23f);
        xrLabel4.StylePriority.UseBorderColor = false;
        xrLabel4.StylePriority.UseBorders = false;
        xrLabel4.StylePriority.UseFont = false;
        xrLabel4.StylePriority.UseTextAlignment = false;
        xrLabel4.Text = "xrLabel1";
        xrLabel4.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel4.BeforePrint += new BeforePrintEventHandler(xrLabel4_BeforePrint);
        xrLabel5.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel5.Borders = BorderSide.Left | BorderSide.Bottom;
        xrLabel5.ExpressionBindings.AddRange(new ExpressionBinding[1]
        {
            new ExpressionBinding("BeforePrint", "Text", "[OutTime]")
        });
        xrLabel5.Font = new DXFont("Tahoma", 9f);
        xrLabel5.LocationFloat = new PointFloat(320.3748f, 0.0f);
        xrLabel5.Multiline = true;
        xrLabel5.Name = "xrLabel5";
        xrLabel5.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel5.SizeF = new SizeF(77.08334f, 23f);
        xrLabel5.StylePriority.UseBorderColor = false;
        xrLabel5.StylePriority.UseBorders = false;
        xrLabel5.StylePriority.UseFont = false;
        xrLabel5.StylePriority.UseTextAlignment = false;
        xrLabel5.Text = "xrLabel1";
        xrLabel5.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel5.TextFormatString = "{0:hh:mm tt}";
        xrLabel5.BeforePrint += new BeforePrintEventHandler(xrLabel5_BeforePrint);
        xrLabel3.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel3.Borders = BorderSide.Left | BorderSide.Bottom;
        xrLabel3.ExpressionBindings.AddRange(new ExpressionBinding[1]
        {
            new ExpressionBinding("BeforePrint", "Text", "[InTime]")
        });
        xrLabel3.Font = new DXFont("Tahoma", 9f);
        xrLabel3.LocationFloat = new PointFloat(235.9998f, 0.0f);
        xrLabel3.Multiline = true;
        xrLabel3.Name = "xrLabel3";
        xrLabel3.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel3.SizeF = new SizeF(84.37497f, 23f);
        xrLabel3.StylePriority.UseBorderColor = false;
        xrLabel3.StylePriority.UseBorders = false;
        xrLabel3.StylePriority.UseFont = false;
        xrLabel3.StylePriority.UseTextAlignment = false;
        xrLabel3.Text = "xrLabel1";
        xrLabel3.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel3.TextFormatString = "{0:hh:mm tt}";
        xrLabel3.BeforePrint += new BeforePrintEventHandler(xrLabel3_BeforePrint);
        xrLabel2.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel2.Borders = BorderSide.Left | BorderSide.Bottom;
        xrLabel2.ExpressionBindings.AddRange(new ExpressionBinding[1]
        {
            new ExpressionBinding("BeforePrint", "Text", "[Day]")
        });
        xrLabel2.Font = new DXFont("Tahoma", 9f);
        xrLabel2.LocationFloat = new PointFloat(92.70837f, 0.0f);
        xrLabel2.Multiline = true;
        xrLabel2.Name = "xrLabel2";
        xrLabel2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel2.SizeF = new SizeF(85.99981f, 23f);
        xrLabel2.StylePriority.UseBorderColor = false;
        xrLabel2.StylePriority.UseBorders = false;
        xrLabel2.StylePriority.UseFont = false;
        xrLabel2.StylePriority.UseTextAlignment = false;
        xrLabel2.Text = "xrLabel1";
        xrLabel2.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel1.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel1.Borders = BorderSide.Left | BorderSide.Bottom;
        xrLabel1.ExpressionBindings.AddRange(new ExpressionBinding[1]
        {
            new ExpressionBinding("BeforePrint", "Text", "[Date]")
        });
        xrLabel1.Font = new DXFont("Tahoma", 9f);
        xrLabel1.LocationFloat = new PointFloat(0.0f, 0.0f);
        xrLabel1.Multiline = true;
        xrLabel1.Name = "xrLabel1";
        xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel1.SizeF = new SizeF(92.70834f, 23f);
        xrLabel1.StylePriority.UseBorderColor = false;
        xrLabel1.StylePriority.UseBorders = false;
        xrLabel1.StylePriority.UseFont = false;
        xrLabel1.StylePriority.UseTextAlignment = false;
        xrLabel1.Text = "xrLabel1";
        xrLabel1.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel1.TextFormatString = "{0:dd/MM/yyyy}";
        Title.BackColor = Color.Transparent;
        Title.BorderColor = Color.Black;
        Title.Borders = BorderSide.None;
        Title.BorderWidth = 1f;
        Title.Font = new DXFont("Arial", 14.25f);
        Title.ForeColor = Color.FromArgb(75, 75, 75);
        Title.Name = "Title";
        Title.Padding = new PaddingInfo(6, 6, 0, 0, 100f);
        DetailCaption1.BackColor = Color.FromArgb(75, 75, 75);
        DetailCaption1.BorderColor = Color.White;
        DetailCaption1.Borders = BorderSide.Left;
        DetailCaption1.BorderWidth = 2f;
        DetailCaption1.Font = new DXFont("Arial", 8.25f, DXFontStyle.Bold);
        DetailCaption1.ForeColor = Color.White;
        DetailCaption1.Name = "DetailCaption1";
        DetailCaption1.Padding = new PaddingInfo(6, 6, 0, 0, 100f);
        DetailCaption1.TextAlignment = TextAlignment.MiddleLeft;
        DetailData1.BorderColor = Color.Transparent;
        DetailData1.Borders = BorderSide.Left;
        DetailData1.BorderWidth = 2f;
        DetailData1.Font = new DXFont("Arial", 8.25f);
        DetailData1.ForeColor = Color.Black;
        DetailData1.Name = "DetailData1";
        DetailData1.Padding = new PaddingInfo(6, 6, 0, 0, 100f);
        DetailData1.TextAlignment = TextAlignment.MiddleLeft;
        DetailData3_Odd.BackColor = Color.FromArgb(231, 231, 231);
        DetailData3_Odd.BorderColor = Color.Transparent;
        DetailData3_Odd.Borders = BorderSide.None;
        DetailData3_Odd.BorderWidth = 1f;
        DetailData3_Odd.Font = new DXFont("Arial", 8.25f);
        DetailData3_Odd.ForeColor = Color.Black;
        DetailData3_Odd.Name = "DetailData3_Odd";
        DetailData3_Odd.Padding = new PaddingInfo(6, 6, 0, 0, 100f);
        DetailData3_Odd.TextAlignment = TextAlignment.MiddleLeft;
        PageInfo.Font = new DXFont("Arial", 8.25f, DXFontStyle.Bold);
        PageInfo.ForeColor = Color.FromArgb(75, 75, 75);
        PageInfo.Name = "PageInfo";
        PageInfo.Padding = new PaddingInfo(6, 6, 0, 0, 100f);
        ReportFooter.Controls.AddRange(new XRControl[19]
        {
            xrLabel52,
            xrLabel50,
            xrLabel51,
            xrLabel42,
            xrLabel43,
            xrLabel44,
            xrLabel45,
            xrLabel46,
            xrLabel47,
            xrLabel48,
            xrLabel49,
            xrLabel34,
            xrLabel35,
            xrLabel36,
            xrLabel37,
            xrLabel38,
            xrLabel39,
            xrLabel40,
            xrLabel41
        });
        ReportFooter.HeightF = 135.7921f;
        ReportFooter.Name = "ReportFooter";
        xrLabel52.Font = new DXFont("Tahoma", 8f);
        xrLabel52.LocationFloat = new PointFloat(0.0f, 66.00005f);
        xrLabel52.Multiline = true;
        xrLabel52.Name = "xrLabel52";
        xrLabel52.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel52.SizeF = new SizeF(706.0001f, 29.66665f);
        xrLabel52.StylePriority.UseFont = false;
        xrLabel52.Text = "Status Legend: P= Present, A= Absent, LI=Late, W=Week End, H=Holiday, LV=Leave, PN= Present Night, WPN=WE Present Night, HPN=Holiday Present Night, LIEO=Late In Early Out";
        xrLabel50.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel50.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Bottom;
        xrLabel50.Font = new DXFont("Tahoma", 9f);
        xrLabel50.LocationFloat = new PointFloat(533.3334f, 13.00013f);
        xrLabel50.Multiline = true;
        xrLabel50.Name = "xrLabel50";
        xrLabel50.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel50.SizeF = new SizeF(75.99994f, 23f);
        xrLabel50.StylePriority.UseBorderColor = false;
        xrLabel50.StylePriority.UseBorders = false;
        xrLabel50.StylePriority.UseFont = false;
        xrLabel50.StylePriority.UseTextAlignment = false;
        xrLabel50.Text = "Holidays";
        xrLabel50.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel51.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel51.Borders = BorderSide.Left | BorderSide.Bottom;
        xrLabel51.ExpressionBindings.AddRange(new ExpressionBinding[1]
        {
            new ExpressionBinding("BeforePrint", "Text", "[Holidays]")
        });
        xrLabel51.Font = new DXFont("Tahoma", 9f);
        xrLabel51.LocationFloat = new PointFloat(533.3334f, 36.00015f);
        xrLabel51.Multiline = true;
        xrLabel51.Name = "xrLabel51";
        xrLabel51.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel51.SizeF = new SizeF(75.99994f, 23f);
        xrLabel51.StylePriority.UseBorderColor = false;
        xrLabel51.StylePriority.UseBorders = false;
        xrLabel51.StylePriority.UseFont = false;
        xrLabel51.StylePriority.UseTextAlignment = false;
        xrLabel51.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel42.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel42.Borders = BorderSide.Left | BorderSide.Bottom;
        xrLabel42.ExpressionBindings.AddRange(new ExpressionBinding[1]
        {
            new ExpressionBinding("BeforePrint", "Text", "[Leave]")
        });
        xrLabel42.Font = new DXFont("Tahoma", 9f);
        xrLabel42.LocationFloat = new PointFloat(165.1664f, 36.00002f);
        xrLabel42.Multiline = true;
        xrLabel42.Name = "xrLabel42";
        xrLabel42.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel42.SizeF = new SizeF(57.29164f, 23f);
        xrLabel42.StylePriority.UseBorderColor = false;
        xrLabel42.StylePriority.UseBorders = false;
        xrLabel42.StylePriority.UseFont = false;
        xrLabel42.StylePriority.UseTextAlignment = false;
        xrLabel42.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel43.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel43.Borders = BorderSide.Left | BorderSide.Bottom;
        xrLabel43.ExpressionBindings.AddRange(new ExpressionBinding[1]
        {
            new ExpressionBinding("BeforePrint", "Text", "[TotalDays]")
        });
        xrLabel43.Font = new DXFont("Tahoma", 9f);
        xrLabel43.LocationFloat = new PointFloat(0.0f, 36.00002f);
        xrLabel43.Multiline = true;
        xrLabel43.Name = "xrLabel43";
        xrLabel43.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel43.SizeF = new SizeF(79.16667f, 23f);
        xrLabel43.StylePriority.UseBorderColor = false;
        xrLabel43.StylePriority.UseBorders = false;
        xrLabel43.StylePriority.UseFont = false;
        xrLabel43.StylePriority.UseTextAlignment = false;
        xrLabel43.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel44.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel44.Borders = BorderSide.Left | BorderSide.Bottom;
        xrLabel44.ExpressionBindings.AddRange(new ExpressionBinding[1]
        {
            new ExpressionBinding("BeforePrint", "Text", "[Present]")
        });
        xrLabel44.Font = new DXFont("Tahoma", 9f);
        xrLabel44.LocationFloat = new PointFloat(79.16666f, 36.00002f);
        xrLabel44.Multiline = true;
        xrLabel44.Name = "xrLabel44";
        xrLabel44.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel44.SizeF = new SizeF(85.99981f, 23f);
        xrLabel44.StylePriority.UseBorderColor = false;
        xrLabel44.StylePriority.UseBorders = false;
        xrLabel44.StylePriority.UseFont = false;
        xrLabel44.StylePriority.UseTextAlignment = false;
        xrLabel44.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel45.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel45.Borders = BorderSide.Left | BorderSide.Bottom;
        xrLabel45.ExpressionBindings.AddRange(new ExpressionBinding[1]
        {
            new ExpressionBinding("BeforePrint", "Text", "[Late]")
        });
        xrLabel45.Font = new DXFont("Tahoma", 9f);
        xrLabel45.LocationFloat = new PointFloat(222.4581f, 36.00006f);
        xrLabel45.Multiline = true;
        xrLabel45.Name = "xrLabel45";
        xrLabel45.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel45.SizeF = new SizeF(73.3752f, 23f);
        xrLabel45.StylePriority.UseBorderColor = false;
        xrLabel45.StylePriority.UseBorders = false;
        xrLabel45.StylePriority.UseFont = false;
        xrLabel45.StylePriority.UseTextAlignment = false;
        xrLabel45.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel46.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel46.Borders = BorderSide.Left | BorderSide.Bottom;
        xrLabel46.ExpressionBindings.AddRange(new ExpressionBinding[1]
        {
            new ExpressionBinding("BeforePrint", "Text", "[Absent]")
        });
        xrLabel46.Font = new DXFont("Tahoma", 9f);
        xrLabel46.LocationFloat = new PointFloat(295.8333f, 36.00009f);
        xrLabel46.Multiline = true;
        xrLabel46.Name = "xrLabel46";
        xrLabel46.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel46.SizeF = new SizeF(77.08334f, 23f);
        xrLabel46.StylePriority.UseBorderColor = false;
        xrLabel46.StylePriority.UseBorders = false;
        xrLabel46.StylePriority.UseFont = false;
        xrLabel46.StylePriority.UseTextAlignment = false;
        xrLabel46.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel47.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel47.Borders = BorderSide.Left | BorderSide.Bottom;
        xrLabel47.ExpressionBindings.AddRange(new ExpressionBinding[1]
        {
            new ExpressionBinding("BeforePrint", "Text", "[Weekend]")
        });
        xrLabel47.Font = new DXFont("Tahoma", 9f);
        xrLabel47.LocationFloat = new PointFloat(372.9166f, 36.00012f);
        xrLabel47.Multiline = true;
        xrLabel47.Name = "xrLabel47";
        xrLabel47.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel47.SizeF = new SizeF(71.875f, 23f);
        xrLabel47.StylePriority.UseBorderColor = false;
        xrLabel47.StylePriority.UseBorders = false;
        xrLabel47.StylePriority.UseFont = false;
        xrLabel47.StylePriority.UseTextAlignment = false;
        xrLabel47.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel48.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel48.Borders = BorderSide.Left | BorderSide.Bottom;
        xrLabel48.ExpressionBindings.AddRange(new ExpressionBinding[1]
        {
            new ExpressionBinding("BeforePrint", "Text", "[OvertimeHr]")
        });
        xrLabel48.Font = new DXFont("Tahoma", 9f);
        xrLabel48.LocationFloat = new PointFloat(444.7916f, 36.00002f);
        xrLabel48.Multiline = true;
        xrLabel48.Name = "xrLabel48";
        xrLabel48.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel48.SizeF = new SizeF(88.54172f, 23f);
        xrLabel48.StylePriority.UseBorderColor = false;
        xrLabel48.StylePriority.UseBorders = false;
        xrLabel48.StylePriority.UseFont = false;
        xrLabel48.StylePriority.UseTextAlignment = false;
        xrLabel48.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel49.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel49.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
        xrLabel49.ExpressionBindings.AddRange(new ExpressionBinding[1]
        {
            new ExpressionBinding("BeforePrint", "Text", "[HwPresent]")
        });
        xrLabel49.Font = new DXFont("Tahoma", 9f);
        xrLabel49.LocationFloat = new PointFloat(609.3334f, 36.00013f);
        xrLabel49.Multiline = true;
        xrLabel49.Name = "xrLabel49";
        xrLabel49.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel49.SizeF = new SizeF(96.66669f, 23f);
        xrLabel49.StylePriority.UseBorderColor = false;
        xrLabel49.StylePriority.UseBorders = false;
        xrLabel49.StylePriority.UseFont = false;
        xrLabel49.StylePriority.UseTextAlignment = false;
        xrLabel49.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel34.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel34.Borders = BorderSide.All;
        xrLabel34.Font = new DXFont("Tahoma", 9f);
        xrLabel34.LocationFloat = new PointFloat(609.3334f, 13.00011f);
        xrLabel34.Multiline = true;
        xrLabel34.Name = "xrLabel34";
        xrLabel34.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel34.SizeF = new SizeF(96.66669f, 23f);
        xrLabel34.StylePriority.UseBorderColor = false;
        xrLabel34.StylePriority.UseBorders = false;
        xrLabel34.StylePriority.UseFont = false;
        xrLabel34.StylePriority.UseTextAlignment = false;
        xrLabel34.Text = "H/W Present";
        xrLabel34.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel35.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel35.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Bottom;
        xrLabel35.Font = new DXFont("Tahoma", 9f);
        xrLabel35.LocationFloat = new PointFloat(444.7916f, 13.00001f);
        xrLabel35.Multiline = true;
        xrLabel35.Name = "xrLabel35";
        xrLabel35.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel35.SizeF = new SizeF(88.54172f, 23f);
        xrLabel35.StylePriority.UseBorderColor = false;
        xrLabel35.StylePriority.UseBorders = false;
        xrLabel35.StylePriority.UseFont = false;
        xrLabel35.StylePriority.UseTextAlignment = false;
        xrLabel35.Text = "Overtime (Hr)";
        xrLabel35.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel36.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel36.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Bottom;
        xrLabel36.Font = new DXFont("Tahoma", 9f);
        xrLabel36.LocationFloat = new PointFloat(372.9166f, 13.0001f);
        xrLabel36.Multiline = true;
        xrLabel36.Name = "xrLabel36";
        xrLabel36.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel36.SizeF = new SizeF(71.875f, 23f);
        xrLabel36.StylePriority.UseBorderColor = false;
        xrLabel36.StylePriority.UseBorders = false;
        xrLabel36.StylePriority.UseFont = false;
        xrLabel36.StylePriority.UseTextAlignment = false;
        xrLabel36.Text = "Weekend";
        xrLabel36.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel37.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel37.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Bottom;
        xrLabel37.Font = new DXFont("Tahoma", 9f);
        xrLabel37.LocationFloat = new PointFloat(295.8333f, 13.00007f);
        xrLabel37.Multiline = true;
        xrLabel37.Name = "xrLabel37";
        xrLabel37.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel37.SizeF = new SizeF(77.08334f, 23f);
        xrLabel37.StylePriority.UseBorderColor = false;
        xrLabel37.StylePriority.UseBorders = false;
        xrLabel37.StylePriority.UseFont = false;
        xrLabel37.StylePriority.UseTextAlignment = false;
        xrLabel37.Text = "Absent Days";
        xrLabel37.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel37.TextFormatString = "{0:dd/MM/yyyy}";
        xrLabel38.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel38.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Bottom;
        xrLabel38.Font = new DXFont("Tahoma", 9f);
        xrLabel38.LocationFloat = new PointFloat(222.4581f, 13.00004f);
        xrLabel38.Multiline = true;
        xrLabel38.Name = "xrLabel38";
        xrLabel38.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel38.SizeF = new SizeF(73.3752f, 23f);
        xrLabel38.StylePriority.UseBorderColor = false;
        xrLabel38.StylePriority.UseBorders = false;
        xrLabel38.StylePriority.UseFont = false;
        xrLabel38.StylePriority.UseTextAlignment = false;
        xrLabel38.Text = "Late Days";
        xrLabel38.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel39.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel39.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Bottom;
        xrLabel39.Font = new DXFont("Tahoma", 9f);
        xrLabel39.LocationFloat = new PointFloat(79.16666f, 13.00001f);
        xrLabel39.Multiline = true;
        xrLabel39.Name = "xrLabel39";
        xrLabel39.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel39.SizeF = new SizeF(85.99981f, 23f);
        xrLabel39.StylePriority.UseBorderColor = false;
        xrLabel39.StylePriority.UseBorders = false;
        xrLabel39.StylePriority.UseFont = false;
        xrLabel39.StylePriority.UseTextAlignment = false;
        xrLabel39.Text = "Present Days";
        xrLabel39.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel40.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel40.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Bottom;
        xrLabel40.Font = new DXFont("Tahoma", 9f);
        xrLabel40.LocationFloat = new PointFloat(0.0f, 13.00001f);
        xrLabel40.Multiline = true;
        xrLabel40.Name = "xrLabel40";
        xrLabel40.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel40.SizeF = new SizeF(79.16667f, 23f);
        xrLabel40.StylePriority.UseBorderColor = false;
        xrLabel40.StylePriority.UseBorders = false;
        xrLabel40.StylePriority.UseFont = false;
        xrLabel40.StylePriority.UseTextAlignment = false;
        xrLabel40.Text = "Total Days";
        xrLabel40.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel40.TextFormatString = "{0:dd/MM/yyyy}";
        xrLabel41.BorderColor = Color.FromArgb(64, 64, 64);
        xrLabel41.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Bottom;
        xrLabel41.Font = new DXFont("Tahoma", 9f);
        xrLabel41.LocationFloat = new PointFloat(165.1664f, 13.00001f);
        xrLabel41.Multiline = true;
        xrLabel41.Name = "xrLabel41";
        xrLabel41.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrLabel41.SizeF = new SizeF(57.29164f, 23f);
        xrLabel41.StylePriority.UseBorderColor = false;
        xrLabel41.StylePriority.UseBorders = false;
        xrLabel41.StylePriority.UseFont = false;
        xrLabel41.StylePriority.UseTextAlignment = false;
        xrLabel41.Text = "Leave";
        xrLabel41.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel53.Borders = BorderSide.Bottom;
        xrLabel53.BorderWidth = 1f;
        xrLabel53.Font = new DXFont("Tahoma", 9f);
        xrLabel53.LocationFloat = new PointFloat(0.0f, 0.0f);
        xrLabel53.Multiline = true;
        xrLabel53.Name = "xrLabel53";
        xrLabel53.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
        xrLabel53.SizeF = new SizeF(137.5f, 23f);
        xrLabel53.StylePriority.UseBorders = false;
        xrLabel53.StylePriority.UseBorderWidth = false;
        xrLabel53.StylePriority.UseFont = false;
        xrLabel53.StylePriority.UsePadding = false;
        xrLabel53.StylePriority.UseTextAlignment = false;
        xrLabel53.Text = "Authorized Signature";
        xrLabel53.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel53.TextFormatString = "{0:dd/MM/yyyy}";
        PageFooter.Controls.AddRange(new XRControl[4]
        {
            xrPageInfo1,
            xrLabel56,
            xrLabel55,
            xrLabel53
        });
        PageFooter.HeightF = 23f;
        PageFooter.Name = "PageFooter";
        xrPageInfo1.Font = new DXFont("Tahoma", 8f);
        xrPageInfo1.LocationFloat = new PointFloat(572f, 0.0f);
        xrPageInfo1.Name = "xrPageInfo1";
        xrPageInfo1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
        xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
        xrPageInfo1.SizeF = new SizeF(133.9999f, 23f);
        xrPageInfo1.StylePriority.UseFont = false;
        xrPageInfo1.StylePriority.UseTextAlignment = false;
        xrPageInfo1.TextAlignment = TextAlignment.MiddleRight;
        xrPageInfo1.TextFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}";
        xrLabel56.Borders = BorderSide.None;
        xrLabel56.Font = new DXFont("Tahoma", 8f, DXFontStyle.Bold);
        xrLabel56.ForeColor = Color.FromArgb(64, 64, 64);
        xrLabel56.LocationFloat = new PointFloat(508f, 0.0f);
        xrLabel56.Multiline = true;
        xrLabel56.Name = "xrLabel56";
        xrLabel56.SizeF = new SizeF(64f, 23f);
        xrLabel56.StylePriority.UseBorders = false;
        xrLabel56.StylePriority.UseFont = false;
        xrLabel56.StylePriority.UseForeColor = false;
        xrLabel56.StylePriority.UsePadding = false;
        xrLabel56.StylePriority.UseTextAlignment = false;
        xrLabel56.Text = "PeoplePro";
        xrLabel56.TextAlignment = TextAlignment.MiddleCenter;
        xrLabel55.Borders = BorderSide.None;
        xrLabel55.Font = new DXFont("Tahoma", 8f);
        xrLabel55.LocationFloat = new PointFloat(430.2917f, 0.0f);
        xrLabel55.Multiline = true;
        xrLabel55.Name = "xrLabel55";
        xrLabel55.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
        xrLabel55.SizeF = new SizeF(77.70831f, 23f);
        xrLabel55.StylePriority.UseBorders = false;
        xrLabel55.StylePriority.UseFont = false;
        xrLabel55.StylePriority.UsePadding = false;
        xrLabel55.StylePriority.UseTextAlignment = false;
        xrLabel55.Text = "Generated by";
        xrLabel55.TextAlignment = TextAlignment.MiddleRight;
        objectDataSource2.DataSource = typeof (AttendanceReportModel);
        objectDataSource2.Name = "objectDataSource2";
        PageHeader.Controls.AddRange(new XRControl[8]
        {
            xrLabel16,
            xrLabel14,
            xrLabel9,
            xrLabel10,
            xrLabel11,
            xrLabel12,
            xrLabel13,
            xrLabel8
        });
        PageHeader.HeightF = 23f;
        PageHeader.Name = "PageHeader";
        Bands.AddRange(new Band[7]
        {
            TopMargin,
            BottomMargin,
            ReportHeader,
            Detail,
            ReportFooter,
            PageFooter,
            PageHeader
        });
        ComponentStorage.AddRange(new IComponent[1]
        {
            objectDataSource2
        });
        DataMember = "AttendanceLines";
        DataSource = objectDataSource2;
        Font = new DXFont("Arial", 9.75f);
        Margins = new DXMargins(55f, 66f, 32.29167f, 36.66636f);
        PageHeight = 1169;
        PageWidth = 827;
        PaperKind = DXPaperKind.A4;
        StyleSheet.AddRange(new XRControlStyle[5]
        {
            Title,
            DetailCaption1,
            DetailData1,
            DetailData3_Odd,
            PageInfo
        });
        Version = "23.2";
        objectDataSource2.EndInit();
        EndInit();
    }
}