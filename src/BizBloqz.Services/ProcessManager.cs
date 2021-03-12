using BizBloqz.Application.Text.Models;
using BizBloqz.Domain;
using BizBloqz.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BizBloqz.Services
{
    public class ProcessManager : IProcessDataManager<Text, TextResponseModel>
    {
        public async Task<TextResponseModel> ProcessDataAsync(IEnumerable<Text> data)
        {
            return await Task.Run(() => {
                #region Requirements
                /*
                 Loop through the data list supplied.
                 Loop through each of the characters in the text property
                 Check each character and count the number of vowels (a,e,i,o,u) 
                 Return the total number of vowels found in the data list
                 */
                #endregion
                // Count of all the vowels
                var count = 0;
                foreach (var item in data)
                {
                    // Loop through all the text supplied and count the number of vowels (a,e,i,o,u)
                    for (var i = 0; i < item.Value.Length; i++)
                    {
                        if (item.Value[i] == 'a')
                        {
                            count++;
                        }

                        if (item.Value[i] == 'e')
                        {
                            count++;
                        }

                        if (item.Value[i] == 'i')
                        {
                            count++;
                        }

                        if (item.Value[i] == 'o')
                        {
                            count++;
                        }

                        if (item.Value[i] == 'u')
                        {
                            count++;
                        }
                    }
                }
                return new TextResponseModel() { VowelCount = count };
            });
        }
        
    }
}
