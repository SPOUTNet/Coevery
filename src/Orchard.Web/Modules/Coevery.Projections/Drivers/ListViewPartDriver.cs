﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Coevery.Projections.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Orchard.Forms.Services;
using Orchard.Projections.FieldTypeEditors;
using Orchard.Projections.Models;

namespace Coevery.Projections.Drivers {

    public class ListViewPartDriver : ContentPartDriver<ListViewPart> {
        private readonly IFormManager _formManager;
        private readonly IEnumerable<IFieldTypeEditor> _fieldTypeEditors;

        public ListViewPartDriver(IFormManager formManager,
            IEnumerable<IFieldTypeEditor> fieldTypeEditors) {
            _formManager = formManager;
            _fieldTypeEditors = fieldTypeEditors;
        }

        protected override DriverResult Display(ListViewPart part, string displayType, dynamic shapeHelper) {
            var editors = _fieldTypeEditors
                .Select(x => x.FormName)
                .Distinct()
                .Select(x => _formManager.Build(x));
            return Combined(
                ContentShape("Parts_ListView",
                    () => shapeHelper.Parts_ListView(FilterEditors: editors)),
                ContentShape("Entity_Buttons", buttons => buttons)
                );
        }
    }
}