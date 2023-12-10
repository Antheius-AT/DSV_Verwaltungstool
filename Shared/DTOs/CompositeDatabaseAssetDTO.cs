//-----------------------------------------------------------------------
// <copyright file="CompositeDatabaseAssetDTO.cs" company="FPSolutions">
//     Copyright (c) FPSolutions. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace SharedDefinitions.DTOs
{
    using System.Collections.Generic;

    public class CompositeDatabaseAssetDTO
    {
        public ICollection<DatabaseAssetDTO> DatabaseAssetDTOs { get; set; }
    }
}
