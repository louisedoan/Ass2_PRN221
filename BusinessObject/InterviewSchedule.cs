using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public partial class InterviewSchedule
    {
        public string InterviewId { get; set; } = null!;
        public string? CandidateId { get; set; }
        public DateTime? InterviewDate { get; set; }
        public string? InterviewLocation { get; set; }
        public string? Interviewer { get; set; }

        public virtual CandidateProfile? Candidate { get; set; }
    }
}
