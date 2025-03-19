<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="My_Pokedex._Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <main class="row">
        <div class="col"></div>

        <div class="col-8">
            <section class="navbar d-flex justify-content-center" role="search">
                <asp:DropDownList runat="server" ID="DdlTypeOfSearch"  OnSelectedIndexChanged="DdlTypeOfSearch_SelectedIndexChanged" CssClass="dropdown btn btn-light me-2" AutoPostBack="true">
                    <asp:ListItem Text="Name or Number"/>
                    <asp:ListItem Text="Pokemon's Type"/>
                    <asp:ListItem Text="Pokemon's Weakness" />
                </asp:DropDownList>
                <asp:DropDownList runat="server" ID="DdlElementsForSearch" OnSelectedIndexChanged="DdlElementsForSearch_SelectedIndexChanged" Visible="false" CssClass="dropdown btn btn-light me-2" AutoPostBack="true">
                   
                </asp:DropDownList>
                <div class="navbar d-flex justify-content-start">
                    <asp:TextBox runat="server" ID="TxtSearchWithoutDB" OnTextChanged="TxtSearchWithoutDB_TextChanged" CssClass="form-control flex-grow-1 me-2" AutoPostBack="true" />
                </div>
                <asp:Button Text="Search" runat="server" ID="BtnSearch" OnClick="BtnSearch_Click" CssClass="btn btn-primary" />
                
            
            </section>
            <section class="row row-cols-1 row-cols-md-3 g-4">

                <asp:Repeater runat="server" ID="RepPokemonCards">
                    <ItemTemplate>
                        <div class="card">
                            <img src="<%#Eval("Url")%>" class="card-img-top" alt="...">
                            <div class="card-body">
                                <h2 class="card-title"><%# Eval("Name")%></h2>
                                <p class="card-text badge text-bg-success"><%#Eval("Type") %></p>
                                <p class="card-text badge text-bg-secondary"><%#Eval("Weakness") %></p>
                                <asp:Button Text="Details" runat="server" ID="BtnViewDetails" OnClick="BtnViewDetails_Click" CssClass="btn btn-primary" CommandArgument='<%#Eval("Id")%>' CommandName="PokemonId" />
                            </div>
                        </div>
                    </ItemTemplate>

                    <SeparatorTemplate>
                        <br />
                    </SeparatorTemplate>
                </asp:Repeater>

            </section>
        </div>

        <div class="col"></div>
    </main>




</asp:Content>
