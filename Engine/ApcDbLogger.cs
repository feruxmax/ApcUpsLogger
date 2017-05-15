using System;
using System.Collections.Generic;
using System.Linq;
using ApcUpsLogger.DataAccess;
using ApcUpsLogger.DataAccess.Entities;

namespace ApcUpsLogger.Engine
{
    public class ApcDbLogger
    {
        private readonly ApcUpsLoggerDbContext dbContext;
        private readonly ApcDevice device;

        public ApcDbLogger(ApcUpsLoggerDbContext dbContext, ApcDevice device)
        {
            this.dbContext = dbContext;
            this.device = device;
        }

        public double? LogLineV()
        {
            var livevParamPair = device.GetParamValue("LINEV");
            var lineV = livevParamPair
                .Split(":")
                .Last()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .First();

            if(Double.TryParse(lineV, out double lineVnumeric))
            {
                dbContext.LineVoltages.Add(new LineVoltage()
                {
                    Value = lineVnumeric
                }
                );
                dbContext.SaveChanges();

                return lineVnumeric;
            }
            else
                return null;
        }
    }
}
