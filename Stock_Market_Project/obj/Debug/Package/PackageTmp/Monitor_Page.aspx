<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="Monitor_Page.aspx.cs" Inherits="Stock_Market_Project.Monitor_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Placeholder1" runat="server">
</asp:Content>
<asp:Content ID="Contenttemp" ContentPlaceHolderID="ContentPlaceHoldertemp" runat="server">
     <div id="Div1">
        <div class="container" >
    <div class="row main-top-margin text-center">
                <div class="col-md-8 col-md-offset-2 col-sm-10 col-sm-offset-1" data-scrollreveal="enter top and move 100px, wait 0.5s">
                    <h1>Monitor Page</h1>
                    
                </div>
            </div>
   <div class="col-md-6 col-sm-6">
           
       <div class="container"    >                     
           <div class="form-group">
 <div style="height: 300px; overflow: scroll ; width:597px">
 <asp:GridView ID="grd_view" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" 
 HeaderStyle-CssClass="header" RowStyle-CssClass="rows"  style="margin-left:105px ; width:300px"  OnRowDataBound="OnRowDataBound"  >
 </asp:GridView>
 </div>
    
           </div>
                                        </div>
            </div>
          </div>
         </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolder2" runat="server">
    
</asp:Content>

