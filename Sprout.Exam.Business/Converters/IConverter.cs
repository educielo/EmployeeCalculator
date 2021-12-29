using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.Business.Converters
{
    /// <summary>
    /// Default contracts for all converter objects
    /// Add only generic conversion, all Object Related Conversions must be on the Implementing Interface
    /// </summary>
    /// <typeparam name="TModel">Entity Class</typeparam>
    /// <typeparam name="TDto">Data Transfer Class</typeparam>
    public interface IConverter<TModel, TDto>
    {
        ///// <summary>
        ///// Convert a dto from a model
        ///// </summary>
        ///// <param name="model">Entity</param>
        ///// <returns>Converted dto</returns>
        //TDto ConvertToDto(TModel model);

        /// <summary>
        /// Convert from dto to model
        /// </summary>
        /// <param name="dto">Dto</param>
        /// <returns>Entity</returns>
        TModel ConvertFromDto(TDto dto);
    }
}
