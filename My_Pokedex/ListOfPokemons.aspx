<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListOfPokemons.aspx.cs" Inherits="My_Pokedex.ListOfPokemons" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .hide {
            display: none;
        }
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <main class="row">
        <section class="col-12">
            <div class="table-responsive">
                <asp:GridView runat="server" ID="Dgv_Pokemons" DataKeyNames="Id" CssClass="table table-striped-columns" AutoGenerateColumns="false" OnSelectedIndexChanged="Dgv_Pokemons_SelectedIndexChanged"
                    OnPageIndexChanging="Dgv_Pokemons_PageIndexChanging" AllowPaging="true" PageSize="6">
                    <Columns>
                        <asp:BoundField HeaderText="Id" DataField="Id" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                        <asp:BoundField HeaderText="Number" DataField="Number" ItemStyle-CssClass="badge" />
                        <asp:BoundField HeaderText="Name" DataField="Name" />
                        <asp:ImageField HeaderText="Picture" DataImageUrlField="Url" ControlStyle-Width="120px" ControlStyle-Height="120px"></asp:ImageField>
                        <asp:CommandField HeaderText="Detail" ShowSelectButton="true" SelectText="👍"  ItemStyle-CssClass="btn btn-primary"/>
                    </Columns>
                </asp:GridView>
            </div>

            <div class="mb-3">
                <a href="Default.aspx" class="btn btn-primary">Coming back?</a>
            </div>
        </section>
    </main>



</asp:Content>
