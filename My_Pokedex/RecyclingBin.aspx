<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecyclingBin.aspx.cs" Inherits="My_Pokedex.RecyclingBin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col"></div>
        <div class="col-12">
            <div class="table-responsive">
                <asp:GridView runat="server" ID="DgvRecycledPokemons" AutoGenerateColumns="false" DataKeyNames="Id" CssClass="table" OnSelectedIndexChanged="DgvRecycledPokemons_SelectedIndexChanged"
                    OnPageIndexChanging="DgvRecycledPokemons_PageIndexChanging" AllowPaging="true" PageSize="6">
                    <Columns>
                        <asp:BoundField HeaderText="Number" DataField="Number" ItemStyle-CssClass="badge" />
                        <asp:BoundField HeaderText="Name" DataField="Name" />
                        <asp:ImageField HeaderText="Picture" DataImageUrlField="Url" ControlStyle-Width="120px" ControlStyle-Height="120px" />
                        <asp:CommandField HeaderText="Reactivate Pokemon?" ShowSelectButton="true" SelectText="👍" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="mb-3">
                <a href="Default.aspx" class="btn btn-primary">Coming back?</a>
            </div>
        </div>
        <div class="col"></div>
    </div>




</asp:Content>
