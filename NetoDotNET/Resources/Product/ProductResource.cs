﻿using NetoDotNET.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetoDotNET.Resources
{
    public class ProductResource : NetoResourceBase
    {
        private readonly StoreConfiguration _storeConfiguration;
        private const string PRODUCT_ENDPOINT = "/products";

        public ProductResource(StoreConfiguration storeCongfiguration, IRestClient restClient) 
            : base(storeCongfiguration, PRODUCT_ENDPOINT, restClient)
        {
            this._storeConfiguration = storeCongfiguration;
        }


        /// <summary>
        /// Use this method to get product data.
        /// </summary>
        /// <param name="GetItemFilter">You must specify at least one filter and one OutputSelector. These will determine the results returned.</param>
        /// <returns>string</returns>
        public Item[] GetItem(GetItemFilter productFilter)
        {
            var resp = (GetItemResponse)Get(productFilter);
            return resp.Item;
        }

        /// <summary>
        /// Use this method to add a new product.
        /// </summary>
        /// <param name="Item">New item to add.</param>
        /// <returns>returns the unique identifier (SKU) for the product, and the date and time the product was added (CurrentTime)</returns>
        public AddItemResponse AddItem(Item[] item)
        {
            AddItemFilter addItemFilter = new AddItemFilter(item);
            var resp = (AddItemResponse)Add(addItemFilter);
            return resp;
        }

        protected override INetoResponse Get(NetoGetResourceFilter productFilter)
        {
            var nRequest = new GetItemRequest((GetItemFilter)productFilter);
           
            return GetResource<GetItemResponse>(nRequest);    
        }

        protected override INetoResponse Add(NetoAddResourceFilter filter)
        {
            var nRequest = new AddItemRequest((AddItemFilter)filter);

            return AddResource<AddItemResponse>(nRequest);
        }
    }
}
