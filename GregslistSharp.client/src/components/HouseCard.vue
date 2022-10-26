<template>
  <div class="card">
    <img class="rounded-top" :src="house?.imgUrl"
      alt="https://3dwarehouse.sketchup.com/warehouse/v1.0/publiccontent/8c172c73-1865-476f-aa0f-f0e9a642dde3">
    <div class="card-body d-flex justify-content-between align-items-center">
      <h5>{{ house?.bedrooms }} bed / {{ house?.bathrooms }} bath</h5>
      <p>$<b>{{ house?.price }}</b></p>
      <!-- <div class="align-items-center d-flex gap-2">
        <img :src="seller.picture" :alt="seller.name" :title="seller.name" height="30" class="rounded">
        <i class="mdi mdi-delete-forever fs-4 selectable rounded" @click.stop="$emit('deleteClassified')"
          v-if="account.id == seller.id"></i>
      </div> -->
    </div>
  </div>
</template>


<script>
import { AppState } from "../AppState.js";
import { computed } from '@vue/reactivity';

export default {
  props: {
    house: { type: Object, required: true },
    // seller: { type: SellerProfile, required: true }
  },
  setup(props, { emit }) {
    return {
      // account: computed(() => AppState.account),
      // deleteClassified() {
      //   emit('deleteClassified')
      // }
    }
  }
}
</script>


<style lang="scss" scoped>

</style>