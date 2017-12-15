<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="Insert_Order_or_Monitor_Users.aspx.cs" Inherits="Stock_Market_Project.Insert_Order_or_Monitor_Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Placeholder1" runat="server">
    <asp:Image ID="Image1" runat="server" />
    <div style="margin-top:20px ; color:white ; margin-left:20px">
    <asp:Label ID="Usr_Name_lbl" Text="" runat="server"></asp:Label>
        </div>
                <asp:Button ID="logout_btn" class="btn btn-primary" Text="Log out" style="margin:-53px 3px 0px 107px ; width:93px" runat="server"  OnClick="on_Click_Logout_Button" />

</asp:Content>
<asp:Content ID="Contenttemp" ContentPlaceHolderID="ContentPlaceHoldertemp" runat="server">
    <div id="Div1">
        <div class="container" >
            <div class="row main-top-margin text-center">
                <div class="col-md-8 col-md-offset-2 col-sm-10 col-sm-offset-1" data-scrollreveal="enter top and move 100px, wait 0.5s">
                    <h1>Insert Order / Monitor User</h1>
                    
                </div>
            </div>



          <div class="container" >
            <div class="row main-top-margin text-center">
                <div class="col-md-8 col-md-offset-2 col-sm-10 col-sm-offset-1" data-scrollreveal="enter top and move 100px, wait 0.5s">
      <div class="col-md-6 col-sm-6">
                                    <div class="form-group">
    <asp:Button ID="insert_Order_Btn" style="margin-top:-25%" class="btn btn-primary" runat="server" text="Insert Order" OnClick="On_Click_Insert_Order" />
                                         <asp:Button ID="monitor_Page_Btn" style="margin-top:-35% ; margin-left:128%" class="btn btn-primary" runat="server" text="Monitor Page" OnClick="On_Click_Monitor_Page_Btn" />
                                        </div>
          </div>
                    </div>
                </div>
            </div>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolder2" runat="server">

    
</asp:Content>

