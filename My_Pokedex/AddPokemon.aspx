<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddPokemon.aspx.cs" Inherits="My_Pokedex.AddPokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <main class="row row-cols-1 row-cols-md-3 g-4  justify-content-center align-items-baseline gap-3">

        <div class="col">
            <div class="mb-3">
                <asp:TextBox runat="server" ID="TxtId" CssClass="form-control mb-3" />
            </div>

            <div class="mb-3">
                <label for="TxtName" class="form-label">Name</label>
                <asp:TextBox runat="server" ID="TxtName" CssClass="form-control mb-3"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="DdlType" class="form-label">Type</label>
                <asp:DropDownList runat="server" ID="DdlType" CssClass="form-select mb-3"></asp:DropDownList>
            </div>

            <div class="mb-3">
                <label for="DdlWeakness" class="form-label">Weakness</label>
                <asp:DropDownList runat="server" ID="DdlWeakness" CssClass="form-select mb-3"></asp:DropDownList>
            </div>
        </div>


        <div class="col">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="TxtNumber" class="form-label">Number</label>
                        <asp:TextBox runat="server" ID="TxtNumber" CssClass="form-control mb-3" AutoPostBack="true" OnTextChanged="TxtNumber_TextChanged"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <label for="TxtDescription" class="form-label">Description</label>
                        <asp:TextBox runat="server" TextMode="MultiLine" ID="TxtDescription" CssClass="form-control mb-3" OnTextChanged="TxtDescription_TextChanged" AutoPostBack="true"> </asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <label for="TxtUrl" class="form-label">Image Url</label>
                        <asp:TextBox runat="server" ID="TxtUrl" CssClass="form-control mb-3" OnTextChanged="TxtUrl_TextChanged" AutoPostBack="true"></asp:TextBox>
                    </div>

                    <asp:Image runat="server" AlternateText="This is an image of a pokemon" ID="ImgPokemon" Width="50%" Height="50%" CssClass=".img-fluid" />

                    <div>
                        <asp:Label Text="" runat="server" CssClass="form-label" ID="ErrorLabel" />
                    </div>
                    <div class="mb-3">
                        <asp:Button runat="server" ID="BtnAdd" CssClass="btn btn-primary btn-lg" Text="Add" OnClick="BtnAdd_Click" />
                        <a href="Default.aspx" class="btn btn-secundary btn-lg">Cancel</a>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </main>

</asp:Content>
