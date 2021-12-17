using Dapper;
using MvxStarter.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvxStarter.Core.Data
{
    public class DataAccess
    {
        public List<MessageModel> GetMessages()
        {
            List<MessageModel> output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AzureChatDB")))
            {
                output = connection.Query<MessageModel>("dbo.ChatHistoryGetAllActive").ToList();
            }

            return output;
        }
        public void UploadMessage(MessageModel newMessage)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AzureChatDB")))
            {

                var p = new DynamicParameters();
                p.Add("@TimeWritten", newMessage.TimeWritten);
                p.Add("@ActiveMessage", newMessage.ActiveMessage);
                p.Add("@UserAlias", newMessage.UserAlias);

                connection.Execute("[dbo].[ChatInsert]", p, commandType: CommandType.StoredProcedure);


                //connection.Query($"Insert into ChattHistory (TimeWritten, @ActiveMessage, @UserAlias) " +
                // $"values({newMessage.TimeWritten}, {newMessage.ActiveMessage}, {newMessage.UserAlias})");
            }

        }
        public List<string> UpdateChatWindow(int listWidth)
        {

            List<String> messages = new List<string>();
            List<MessageModel> MessagesInList = GetMessages();
            foreach (var item in MessagesInList)
            {
                messages.Add(" -" + item.TimeWritten.ToShortTimeString() + "-" + item.UserAlias + "- ");

                if (item.ActiveMessage.Length > listWidth)
                {
                    int chunkSize = listWidth - 1;
                    int stringLength = item.ActiveMessage.Length;
                    for (int i = 0; i < stringLength; i += chunkSize)
                    {
                        if (i + chunkSize > stringLength) chunkSize = stringLength - i;
                        messages.Add(item.ActiveMessage.Substring(i, chunkSize));
                    }
                }
                else
                {
                    messages.Add(item.ActiveMessage);
                }



                messages.Add("                                             ");
            }

            return messages;
        }

    }
}
