using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.IO;

namespace GraphQL.Samples.Chapter2
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            app.Run(async (context) =>
            {
                if (context.Request.Path.StartsWithSegments("/api/graphql") &&
                    string.Equals(context.Request.Method, "POST", StringComparison.OrdinalIgnoreCase))
                {
                    using (var stream = new StreamReader(context.Request.Body))
                    {
                        var body = stream.ReadToEndAsync().Result;
                        var request = JsonConvert.DeserializeObject<GraphQLRequest>(body);

                        var schema = new Schema
                        {
                            Query = new HelloWorldQuery()
                        };


                        var result = await new DocumentExecuter()
                            .ExecuteAsync(doc =>
                            {
                                doc.Schema = schema;
                                doc.Query = request.Query;
                            }).ConfigureAwait(false);

                        var json = new DocumentWriter(indent: true)
                            .Write(result);
                        await context.Response.WriteAsync(json);
                    }


                }
            });
        }
    }
}
