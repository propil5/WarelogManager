using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarelogManager.Model.Common.Response
{
    public class DtoResponse : BaseResponse
    {
        public object Dto { get; private set; }

        private DtoResponse(bool success, string message, object dto) : base(success, message)
        {
            Dto = dto;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="product">Saved dto.</param>
        /// <returns>Response.</returns>
        public DtoResponse(object Dto) : this(true, string.Empty, Dto)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public DtoResponse(string message) : this(false, message, null)
        { }
    }
}
