using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomesEngland.Gateway.Migrations
{
    public partial class FullCsv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "monthpaid",
                table: "assets",
                newName: "tenure");

            migrationBuilder.RenameColumn(
                name: "accountingyear",
                table: "assets",
                newName: "propertytype");

            migrationBuilder.AddColumn<decimal>(
                name: "actualagencyequitycostincludinghomebuyagentfee",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "agencyfairvalue",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "agencyfairvaluedifference",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "agencypercentage",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "arrearseffectappliedorlimited",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "calendaryear",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "col",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "developerdiscount",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "disposalmonthsincecompletion",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "disposalscost",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "durationinmonths",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "earlymortgageifneverrepay",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "equityowner",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "estimatedsaleprice",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "expectedstaircasingrate",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "fairvaluereserve",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "fees",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "firsttimebuyer",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fulldisposaldate",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "hpiend",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "hpiplusminus",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "hpistart",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "historicunallocatedfees",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "housetype",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "householdfiftykincomeband",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "householdfivekincomeband",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "imspaymentdate",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "impairmentprovision",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "invested",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isasset",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "islondon",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ispaid",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lbha",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "mmyyyy",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "month",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "monthofcompletionsinceschemestart",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "mortgage",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "mortgageeffect",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "mortgageprovider",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "newagencypercentage",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "notlimitedbyfirstcharge",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "originalagencypercentage",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "programme",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "propertyhousename",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "propertypostcode",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "propertystreet",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "propertystreetnumber",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "propertytown",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "purchaseprice",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "purchasepriceband",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "quarterspend",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "regionalsaleadjust",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "regionalstairadjust",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "relativesalepropertytypeandtenureadjustment",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "relativestairpropertytypeandtenureadjustment",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "remainingagencycost",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "row",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "staircasingpercentage",
                table: "assets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "waestimatedpropertyvalue",
                table: "assets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "actualagencyequitycostincludinghomebuyagentfee",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "agencyfairvalue",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "agencyfairvaluedifference",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "agencypercentage",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "arrearseffectappliedorlimited",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "calendaryear",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "col",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "developerdiscount",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "disposalmonthsincecompletion",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "disposalscost",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "durationinmonths",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "earlymortgageifneverrepay",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "equityowner",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "estimatedsaleprice",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "expectedstaircasingrate",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "fairvaluereserve",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "fees",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "firsttimebuyer",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "fulldisposaldate",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "hpiend",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "hpiplusminus",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "hpistart",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "historicunallocatedfees",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "housetype",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "householdfiftykincomeband",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "householdfivekincomeband",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "imspaymentdate",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "impairmentprovision",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "invested",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "isasset",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "islondon",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "ispaid",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "lbha",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "mmyyyy",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "month",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "monthofcompletionsinceschemestart",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "mortgage",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "mortgageeffect",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "mortgageprovider",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "newagencypercentage",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "notlimitedbyfirstcharge",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "originalagencypercentage",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "programme",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "propertyhousename",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "propertypostcode",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "propertystreet",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "propertystreetnumber",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "propertytown",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "purchaseprice",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "purchasepriceband",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "quarterspend",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "regionalsaleadjust",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "regionalstairadjust",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "relativesalepropertytypeandtenureadjustment",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "relativestairpropertytypeandtenureadjustment",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "remainingagencycost",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "row",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "staircasingpercentage",
                table: "assets");

            migrationBuilder.DropColumn(
                name: "waestimatedpropertyvalue",
                table: "assets");

            migrationBuilder.RenameColumn(
                name: "tenure",
                table: "assets",
                newName: "monthpaid");

            migrationBuilder.RenameColumn(
                name: "propertytype",
                table: "assets",
                newName: "accountingyear");
        }
    }
}
