using Character.Repository.Model;
using Character.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Utility.Kafka.Constants;
using Utility.Kafka.Messages;

namespace Character.Business.Factory
{
    public static class TransactionalOutboxFactory
    {
        public static TransactionalOutbox CreateInsert(CharacterDTO characterDTO)
        {
            return Create(characterDTO, Operations.Insert);
        }

        public static TransactionalOutbox CreateDelete(CharacterDTO characterDTO)
        {
            return Create(characterDTO, Operations.Delete);
        }

        public static TransactionalOutbox CreateUpdate(CharacterDTO characterDTO)
        {
            return Create(characterDTO, Operations.Update);
        }

        private static TransactionalOutbox Create(CharacterDTO characterDTO, string insert)
        {
            return Create(nameof(CharacterDb), characterDTO, insert);
        }

        private static TransactionalOutbox Create<TDTO>(string v, TDTO characterDTO, string insert) where TDTO : class, new()
        {
            OperationMessage<TDTO> operationMessage = new OperationMessage<TDTO>()
            {
                Dto = characterDTO,
                Operation = insert
            };
            operationMessage.CheckMessage();

            return new TransactionalOutbox()
            {
                Tabella = v,
                Messaggio = JsonSerializer.Serialize(operationMessage)
            };
        }
    }
}
