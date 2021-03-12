using BizBloqz.Application.Text.Models;
using BizBloqz.Domain;
using BizBloqz.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizBloqz.Services
{
    public class ProcessManagerLite : IProcessDataManager<Text, TextResponseModel>
    {
        public async Task<TextResponseModel> ProcessDataAsync(IEnumerable<Text> data)
        {
            return await Task.Run(() =>
            {
                var count = 0;
                var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
                foreach (var text in data)
                {
                    count += text.Value.Count(a => vowels.Contains(a));
                }
                return new TextResponseModel() { VowelCount = count };
            });
        }
    }
}
