using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character.Business.Kafka
{
    public class KafkaTopicsOutput : AbstractKafkaTopics
    {
        public string Character { get; set; } = "Character";
        public override IEnumerable<string> GetTopics()
        {
            return new List<string>() { Character };
        }
    }
}
