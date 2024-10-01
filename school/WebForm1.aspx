<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="school.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Details</title>
</head>
<body>
    <form id="Student_Details" runat="server">
        <div>
            <center>
            <table>
                <tr>
                    <td>Student Name: </td>
                    <td><asp:TextBox runat="server" ID="txtname"></asp:TextBox></td>
                    <td><asp:TextBox runat="server" ID="txtsearch" placeholder="Search"></asp:TextBox></td>
                    <td><asp:Button runat="server" Text="Search" ID="btnsearch" OnClick="btnsearch_Click" ></asp:Button></td>
                    <td><asp:Button runat="server" Text="Sorted Data" ID="btnsort" OnClick="btnsort_Click" ></asp:Button></td>
                </tr>
                <tr>
                    <td>Student Subject: </td>
                    <td><asp:TextBox runat="server" ID="txtsubject"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Student Class: </td>
                    <td><asp:TextBox runat="server" ID="txtClass"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button id="txtsubmit" runat="server" Text="Submit" OnClick="txtsubmit_Click"/></td>
                </tr>
               </table>
                <asp:GridView runat="server" ID="gv" AutoGenerateColumns="False" OnRowCommand="gv_RowCommand" width="100%" style="text-align:center" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="STUDENT ID">
                            <ItemTemplate>
                                <%#Eval("std_id") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="STUDENT NAME">
                            <ItemTemplate>
                                <%#Eval("std_name") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="STUDENT SUBJECT">
                            <ItemTemplate>
                                <%#Eval("std_sub") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="STUDENT CLASS">
                            <ItemTemplate>
                                   <%#Eval("std_class") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                   <asp:LinkButton ID="btndel" runat="server" Text="Delete" CommandName="del" CommandArgument='<%#Eval("std_id") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                   <asp:LinkButton ID="btnedit" runat="server" Text="Edit" CommandName="thedit" CommandArgument='<%#Eval("std_id") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </center>
        </div>
    </form>
</body>
</html>
