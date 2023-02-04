﻿using Core.Entities.Abstract;

namespace Entities.Concrete
{
	class UserOperationClaim :IEntity
	{
		public int Id { get; set; }

		public int UserId { get; set; }

		public int OperationClaimId { get; set; }
	}
}