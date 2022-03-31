// Document , Index , Shard, Replicas, Nodes, Cluster

using Elastic.Terminal;

using Nest;

ResellerExample();
KibanaExample();


Console.ReadKey();

void ResellerExample()
{
    ConnectionSettings connectionSettings = new(new Uri("http://#ElasticSearchIP#:9200"));
    connectionSettings.DefaultIndex("reseller_index");

    ElasticClient client = new(connectionSettings);

    //ConfigureElasticIndex(client);
    var searchScrollResponse = client.Search<Reseller>(query => query.From(0)
        .Size(100)
        .Scroll("10s"));

}

void ConfigureElasticIndex(ElasticClient elasticClient)
{
    var indexGetResponse = elasticClient.Indices.Get("reseller_index");

    if (!indexGetResponse.IsValid || indexGetResponse.Indices.Count == 0)
    {
        var indexCreateResponse = elasticClient.Indices.Create("reseller_index");
    }

    var resellers = SQLHelper.GetResellers();

    foreach (var reseller in resellers)
    {
        var indexDocumentResponse = elasticClient.IndexDocument(reseller);
    }
}

void KibanaExample()
{
    ConnectionSettings connectionSettings = new(new Uri("http://#ElasticSearchIP#:9200"));
    connectionSettings.DefaultIndex("kibana_sample_data_ecommerce");

    ElasticClient client = new(connectionSettings);


    var searchPagingResponse = client.Search<Order>(query => query.From(0)
        .Size(100));

    //ElasticScrollSearch(client);


    var searchUserResponse = client.Search<Order>(query =>
        query.Query(q =>
            q.Term(t => t.user, "robbie")));


    var searchUserDateRangeResponse = client.Search<Order>(query =>
        query.Query(q =>
            q.DateRange(dr =>
                dr.Field(f => f.order_date)
                    .LessThan(DateMath.Now)
                    .GreaterThan(DateMath.FromString("2022-01-01")))));
}

void ElasticScrollSearch(ElasticClient client)
{
    var searchScrollResponse = client.Search<Order>(query => query.From(0)
        .Size(100)
        .Scroll("10s"));


    while (searchScrollResponse.Documents.Any())
    {
        searchScrollResponse = client.Scroll<Order>("10s", searchScrollResponse.ScrollId);
    }
}