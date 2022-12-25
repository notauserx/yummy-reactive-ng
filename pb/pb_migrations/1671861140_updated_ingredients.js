migrate((db) => {
  const dao = new Dao(db)
  const collection = dao.findCollectionByNameOrId("uododknfckaqt1l")

  // add
  collection.schema.addField(new SchemaField({
    "system": false,
    "id": "r4unqm2n",
    "name": "recipeId",
    "type": "relation",
    "required": false,
    "unique": false,
    "options": {
      "maxSelect": null,
      "collectionId": "02m04h8oj0df37u",
      "cascadeDelete": false
    }
  }))

  return dao.saveCollection(collection)
}, (db) => {
  const dao = new Dao(db)
  const collection = dao.findCollectionByNameOrId("uododknfckaqt1l")

  // remove
  collection.schema.removeField("r4unqm2n")

  return dao.saveCollection(collection)
})
