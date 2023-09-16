from pyspark.sql import SparkSession
from pyspark.sql.functions import broadcast, coalesce, collect_list

spark = SparkSession.builder.getOrCreate()
products = spark.createDataFrame([
    (1, "Product A"),
    (2, "Product B"),
    (3, "Product C")
], ["ProductID", "ProductName"])

categories = spark.createDataFrame([
    (1, "Category X"),
    (2, "Category Y"),
    (1, "Category Z")
], ["ProductID", "CategoryName"])
products = products.withColumnRenamed("ProductID", "ID").withColumnRenamed("ProductName", "Name")
categories = categories.withColumnRenamed("ProductID", "ID").withColumnRenamed("CategoryName", "Name")
result = products.join(broadcast(categories), on="ID", how="left")
result = result.select("Name", coalesce("Name", "No Category").alias("CategoryName"))
result = result.groupBy("Name").agg(collect_list("CategoryName").alias("CategoryNames"))
result.show()
