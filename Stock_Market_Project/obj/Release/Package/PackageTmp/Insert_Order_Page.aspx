<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="Insert_Order_Page.aspx.cs" Inherits="Stock_Market_Project.Insert_Order_Page" EnableEventValidation="false" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Placeholder1" runat="server">
                    <asp:Button ID="logout_btn" class="btn btn-primary" Text="Log out" style="margin:-53px 3px 0px 107px ; width:93px" runat="server"  OnClick="on_Click_Logout_Button" />

</asp:Content>
<asp:Content ID="Contenttemp" ContentPlaceHolderID="ContentPlaceHoldertemp" runat="server">
           
    <div id="Div1">
        <div class="container" >
            <div class="row main-top-margin text-center">
                <div class="col-md-8 col-md-offset-2 col-sm-10 col-sm-offset-1" data-scrollreveal="enter top and move 100px, wait 0.5s">
                    <h1>Insert Order</h1>
                    
                </div>
            </div>

      


            <!-- ./ Main Heading-->
            <div class="row">
                <div class="col-md-12  col-sm-12 ">
                    <div class="col-md-6  col-sm-12" data-scrollreveal="enter left and move 100px, wait 0.8s">
                      
                       
                      
                      
                    </div>
                    <div class="col-md-6  col-sm-12" data-scrollreveal="enter right and move 100px, wait 0.8s" >
                        <div>
                        <form >
                            <div class="row">
                                <div class="col-md-6 col-sm-6">
                                    <div class="form-group">
                                        <asp:RequiredFieldValidator ID="ReqValFname" runat="server" ErrorMessage="*" ControlToValidate="user_txt" validationgroup="Buy/Sell" style="margin-left:-75% ; color:red "></asp:RequiredFieldValidator>
                                        <input type="text" class="form-control"  placeholder="User" style="margin-left:-180%;margin-top:-20px" id="user_txt" runat="server"  readonly="readonly">
                                        
                                        <br />
                                       
                                        <asp:RequiredFieldValidator ID="ReqValSavings" runat="server" ErrorMessage="*" ControlToValidate="tdate_txt" validationgroup="Buy/Sell" style="margin-left:110%  ;color:red "></asp:RequiredFieldValidator>
                                        <input type="text" class="form-control"  placeholder="Transaction Date" style="margin-left:-180% ; margin-top:-10%" id="tdate_txt" runat="server" readonly="readonly">
                                        <br />
                                        <asp:RequiredFieldValidator ID="ReqValPass" runat="server" ErrorMessage="*" ControlToValidate="qty_txt" validationgroup="Buy/Sell" style="margin-left:-75% ; color:red "></asp:RequiredFieldValidator>
                                        <input type="text" class="form-control"  placeholder="Quantity" style="margin-left:-180% ; margin-top:-10%" id="qty_txt" runat="server"  >
                                    <div style="margin-left:-132px ; margin-top:12px; font-weight:bold ;color:red" ><asp:Label ID="message" runat="server" Text="" ></asp:Label></div>
                                    </div>
                                </div>


                                    
                                      
                                         
                                         
                                 


                                <div class="col-md-6 col-sm-6">
                                    <div class="form-group">
                                         
                                         
                                         <input type="text" class="form-control"  placeholder="Price of Stock " style="margin-left:-41%;margin-top:-6px" id="priceofstock_txt" runat="server"  readonly="readonly">
                                        
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="dropdownliststocks" validationgroup="Buy/Sell" style="margin-left:-75% ; color:red "></asp:RequiredFieldValidator>
                                        <asp:DropDownList ID="dropdownliststocks" runat="server" Style="width: 150px ; margin-left:75px ; margin-top:12px"   OnSelectedIndexChanged="On_Selected_Index_Changed" AutoPostBack="True"></asp:DropDownList>


                                        <br />
                                       
                                        
                                        
                                        <asp:Button ID="Buy_Btn" class="btn btn-primary" runat="server" style="margin-left:-41% ; margin-bottom:-11px; margin-top:5px; width:80px ; margin-right:123px" OnClick="On_Click_Buy_Btn" Text="Buy" validationgroup="Buy/Sell" />
                                        
                                        <asp:Button ID="Sell_Btn" class="btn btn-primary" runat="server" style="margin-left:-13% ; width:80px ; margin-bottom:-9px ; margin-top:7px" Text="Sell" validationgroup="Buy/Sell" OnClick="On_Click_Sell_Button"/>
                                    </div>
                                </div>
                             
                                 

                             
                                           
                                   
                            </div>
                            <div class="row">
                                <div class="col-md-12 col-sm-12">
                                   
                                    <div class="form-group">
                                        
                                       
                                    </div>
                                </div>
                            </div>
                        </form>
                    </div>
                       </div>
                    
                </div>
            </div>
             <!-- ./ Row Content-->
        </div>
    </div>  
    <!--END CONTACT SECTION --> 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolder2" runat="server">
  
      
   
 

      
</asp:Content>

