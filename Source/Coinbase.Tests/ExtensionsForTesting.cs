using System;
using System.Linq;
using FluentAssertions;
using Flurl.Http.Testing;
using Newtonsoft.Json;

namespace Coinbase.Tests
{
   internal static class ExtensionsForTesting
   {
      public static void Dump(this object obj)
      {
         Console.WriteLine(obj.DumpString());
      }

      public static string DumpString(this object obj)
      {
         return JsonConvert.SerializeObject(obj, Formatting.Indented);
      }

      public static HttpCallAssertion ShouldHaveExactCall(this HttpTest test, string exactUrl)
      {
         test.CallLog.First().FlurlRequest.Url.ToString().Should().Be(exactUrl);
         return new HttpCallAssertion(test.CallLog);
      }
      public static HttpCallAssertion ShouldHaveRequestBody(this HttpTest test, string json)
      {
         test.CallLog.First().RequestBody.Should().Be(json);
         return new HttpCallAssertion(test.CallLog);
      }
   }
}
